namespace Puncher;

public interface IPuncherFactory
{
    Task<IPuncher> CreatePuncherAsync(string account, string password);
}