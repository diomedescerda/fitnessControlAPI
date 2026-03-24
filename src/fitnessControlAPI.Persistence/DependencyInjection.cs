using Microsoft.Extensions.DependencyInjection;

namespace fitnessControlAPI.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        var currentAssembly = typeof(DependencyInjection).Assembly;
        return services;
    }
}
