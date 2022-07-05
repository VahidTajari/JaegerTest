using System.Reflection;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders.Thrift;
using OpenTracing;
using OpenTracing.Util;

namespace User
{
    public static class Extensions
    {
        public static void AddJaeger(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("JaegerConfig").Get<JaegerConfig>();
            
            if (!(config?.IsEnabled ?? false))
                return;

            if (string.IsNullOrEmpty(config?.Host))
                throw new Exception("invalid JaegerConfig");

            services.AddSingleton<ITracer>(serviceProvider =>
            {
                string serviceName = Assembly.GetEntryAssembly()?.GetName().Name;

                ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                var sampler = new ProbabilisticSampler(config.SamplingRate); 

                var reporter = new RemoteReporter.Builder()
                    .WithLoggerFactory(loggerFactory)
                    .WithSender(new UdpSender(config.Host, config.Port, 0))
                    .WithFlushInterval(TimeSpan.FromSeconds(15))
                    .WithMaxQueueSize(300)
                    .Build();
                
                ITracer tracer = new Tracer.Builder(serviceName)
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler)
                    .WithReporter(reporter)
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });

            services.AddOpenTracing();
        }
    }
}
