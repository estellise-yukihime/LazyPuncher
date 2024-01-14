using PuppeteerSharp;

namespace Puncher;

public abstract class BasePuncher(IBrowser browser, string account, string password) : IPuncher
{
    protected readonly IBrowser browser = browser;
    protected readonly string account = account;
    protected readonly string password = password;

    public abstract Task SignInAsync();

    public abstract Task SignOutAsync();

    public abstract Task BreakStartAsync();

    public abstract Task BreakOverAsync();
}