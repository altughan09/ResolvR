using System.Diagnostics.CodeAnalysis;
using ResolvR.Domain.Entities;

namespace ResolvR.Infrastructure.Persistence.SeedData;

[ExcludeFromCodeCoverage]
public static class BrandSeedData
{
    public static List<Brand> GetBrandsList()
    {
        return
        [
            new Brand(
                id: Guid.NewGuid(),
                name: "McDonald's",
                description: "Tradycyjny, działający od lat sieciowy fast food znany z burgerów i frytek.",
                logoUrl: "https://cdn.mcdonalds.pl/public/build/images/header/logo3.19d7d61fd29210afe458d0de4d0a7ca6.svg",
                websiteUrl: "https://mcdonalds.pl"
            )
        ];
    }
}