using PuppeteerSharp;

namespace Puncher.Puncher;

public class SheetsPuncher(IBrowser browser, string account, string password) : BasePuncher(browser, account, password)
{
    public override async Task SignInAsync()
    {
        var page = await browser.NewPageAsync();

        await page.GoToAsync("https://accounts.intuit.com/", DefaultNavigationOptions());

        await page.WaitForSelectorAsync("input[name='Email']");
        await page.FocusAsync("input[name='Email']");
        await page.TypeAsync("input[name='Email']", account);

        await page.WaitForSelectorAsync("button[type='submit']");
        await page.ClickAsync("button[type='submit']");

        await page.WaitForNavigationAsync(DefaultNavigationOptions());

        await page.WaitForSelectorAsync("input[name='Password']");
        await page.FocusAsync("input[name='Password']");
        await page.TypeAsync("input[name='Password']", password);

        await page.WaitForSelectorAsync("input[type='submit'");
        await page.ClickAsync("input[type='submit']");

        await page.WaitForNavigationAsync(DefaultNavigationOptions());
    }

    public override Task SignOutAsync()
    {
        throw new NotImplementedException();
    }

    public override Task BreakStartAsync()
    {
        throw new NotImplementedException();
    }

    public override Task BreakOverAsync()
    {
        throw new NotImplementedException();
    }

    private NavigationOptions DefaultNavigationOptions()
    {
        return new NavigationOptions
        {
            WaitUntil = [WaitUntilNavigation.Networkidle0],
            Timeout = 60 * 1000 // seconds * milliseconds
        };
    }
}