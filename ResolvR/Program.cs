using Microsoft.EntityFrameworkCore;
using ResolvR.Application.Extensions;
using ResolvR.Domain.Entities;
using ResolvR.Extensions;
using ResolvR.Infrastructure.Extensions;
using ResolvR.Infrastructure.Persistence;
using Serilog;

namespace ResolvR;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddAuthentication();
        builder.AddPresentation();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure();
        
        builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                options =>
                {
                    options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                });

            if (builder.Environment.IsDevelopment())
            {
                dbContextOptions.EnableDetailedErrors();
            }
        });
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapGroup("api/identity").MapIdentityApi<User>();
        
        app.UseSerilogRequestLogging();
        
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}