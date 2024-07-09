using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ResolvR.Infrastructure.Persistence;

[ExcludeFromCodeCoverage]
public static class DbMigrator
{
    public static void Migrate(IApplicationBuilder app)
    {
        try
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
        catch (SqlException sqlException)
        {
            Console.WriteLine(sqlException);
            throw;
        }
    }
}