using System.Diagnostics;
using System.Text.Json;

using Microsoft.Extensions.Configuration;

// string settingsText; 
// if (Debugger.IsAttached)
// {
//     settingsText = File.ReadAllText("appsettings.development.json");
// }
// else
// {
//     settingsText = File.ReadAllText("appsettings.json");
// }
// var settings = JsonSerializer.Deserialize<AppData>(settingsText);
// Console.WriteLine(settings);

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile("appsettings.development.json", true)
    .AddUserSecrets<Settings>()
    .Build();
var settings = config.Get<Settings>();
foreach (var item in settings.AllowedHosts)
{
    Console.WriteLine(item);
}
Console.WriteLine(settings.AppData);
Console.WriteLine(settings.ApiData);

public class Settings
{
    public AppData AppData { get; set; }
    public ApiData ApiData { get; set; }
    public string[] AllowedHosts { get; set; }
}

public class AppData
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string Version { get; init; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Version: {Version}";
    }
}

public class ApiData

{
    public string ClientId { get; init; }
    public string ClientSecret { get; init; }

    public override string ToString()
    {
        return $"ClientId: {ClientId}, ClientSecret: {ClientSecret}";
    }
}

