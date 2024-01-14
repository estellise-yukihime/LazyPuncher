using PuppeteerSharp;

namespace Puncher;

public interface IPuppeteerCreator
{
    Task<IBrowser> CreateBrowserAsync();
    Task<IEnumerable<IPage>> PagesAsync();
}