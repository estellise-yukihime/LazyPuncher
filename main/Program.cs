// See https://aka.ms/new-console-template for more information

using CommandLine;
using main;
using main.Option;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Puncher.HostBuilderExtension;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
{
    Args = args,
    EnvironmentName = environment
});

builder.Configuration
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false, true)
    .AddEnvironmentVariables();

builder.Services.AddLogging(x =>
{
    x.AddConfiguration(builder.Configuration);
});

builder.Services.AddPuncher();

var host = builder.Build();
var worker = new MainWork(host.Services);
var parser = new Parser(settings =>
{
    settings.AutoHelp = false;
    settings.AutoVersion = false;
});

try
{
    var parsed = parser.ParseArguments<MainOption>(args);

    parsed.WithParsed(worker.Parsed);
    parsed.WithNotParsed((errors) => worker.ParsedError(errors, parsed));
    
    host.Run();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
catch (OperationCanceledException ex)
{
    // do nothing for now
}