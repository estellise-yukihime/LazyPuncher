using Puncher.Puncher;

namespace Puncher.Factory;

public class MainPuncherFactory(IPuppeteerCreator browser) : IPuncherFactory
{
    public static string Sample()
    {
        return "";
    }

    public async Task<IPuncher> CreatePuncherAsync(string account, string password)
    {
        return new SheetsPuncher(await browser.CreateBrowserAsync(), account, password);
    }
}