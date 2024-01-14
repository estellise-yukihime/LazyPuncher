using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Puncher.Factory;

namespace Puncher.HostBuilderExtension;

public static class HostBuilderExtension
{
    public static void AddPuncher(this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
    {
        serviceCollection.TryAdd(new ServiceDescriptor(typeof(IPuppeteerCreator), typeof(PuppeteerCreator), serviceLifetime));
        serviceCollection.TryAdd(new ServiceDescriptor(typeof(IPuncherFactory), typeof(MainPuncherFactory), serviceLifetime));
    }
}