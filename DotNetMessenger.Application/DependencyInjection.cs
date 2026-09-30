using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetMessenger.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        return services;
    }
}
