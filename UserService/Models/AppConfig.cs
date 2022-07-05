namespace User.Models;

public class AppConfig
{
    public  Github Github { get; set; }
}

public class Github
{
    public string BaseAddress { get; set; }

    public string ProfileUrl { get; set; }

    public string RepoUrl { get; set; }

    public int Timeout { get; set; }

    public string User { get; set; }

    public string Password { get; set; }
}