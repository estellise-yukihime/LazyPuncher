using System.Diagnostics;
using CommandLine;
using CommandLine.Text;
using main.Option;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace main;

public class MainWork(IServiceProvider provider)
{
    public void Parsed(MainOption mainOption)
    {
        if (mainOption.Version)
        {
            Console.WriteLine($"v{GetProductVersion()}");
        }

        if (mainOption.Type.Count > 0)
        {
            
        }
    }

    public void ParsedError(IEnumerable<Error> errors, ParserResult<MainOption> parsed)
    {
        var errorsList = errors.ToList();

        if (errorsList.IsHelp())
        {
            var helpText = HelpText.AutoBuild(parsed,
                x =>
                {
                    x.Heading = $"v{GetProductVersion()}";
                    x.AdditionalNewLineAfterOption = false;

                    return x;
                });

            Console.WriteLine(helpText);
        }

        provider.GetService<IHostApplicationLifetime>()!
            .StopApplication();
    }

    private string? GetProductVersion()
    {
        var versionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(AppContext.BaseDirectory, "main.dll"));
        var product = versionInfo.ProductVersion;
        var version = product?[..product.IndexOf('+')];

        return version;
    }
}