namespace Puncher;

public interface IPuncher
{
    Task SignInAsync();
    Task SignOutAsync();
    Task BreakStartAsync();
    Task BreakOverAsync();
}