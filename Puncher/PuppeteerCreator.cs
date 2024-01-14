using PuppeteerSharp;

namespace Puncher;

public class PuppeteerCreator : IPuppeteerCreator
{
    private static IBrowser? singleBrowserInstance;
    
    public async Task<IBrowser> CreateBrowserAsync()
    {
        if (singleBrowserInstance is { IsConnected: true, IsClosed: false })
        {
            return singleBrowserInstance;
        }

        using (var browserFetcher = new BrowserFetcher())
        {
            await browserFetcher.DownloadAsync();
        }

        singleBrowserInstance = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            DefaultViewport = new ViewPortOptions
            {
                Width = 800,
                Height = 800
            },
            Headless = true
        });

        return singleBrowserInstance;
    }

    public async Task<IEnumerable<IPage>> PagesAsync()
    {
        if (singleBrowserInstance is { IsConnected: true, IsClosed: false })
        {
            return await singleBrowserInstance.PagesAsync();
        }

        return [];
    }
}