using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using User;
using User.Models;
using User.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("github", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("AppConfig:Github:BaseAddress"));
    client.Timeout = TimeSpan.FromSeconds(builder.Configuration.GetValue<int>("AppConfig:Github:Timeout"));
    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyTestAppTasks", "1.0"));
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
  
});

builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));

builder.Services.AddScoped<IUserService,User.Services.UserService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddJaeger(builder.Configuration);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
