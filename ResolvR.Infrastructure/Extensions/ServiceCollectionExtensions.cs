using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using ResolvR.Domain.Abstractions;
using ResolvR.Infrastructure.Repositories;
using BrandRepository = ResolvR.Infrastructure.Repositories.BrandRepository;

namespace ResolvR.Infrastructure.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}