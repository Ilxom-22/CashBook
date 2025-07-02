using System.Reflection;
using CashBook.Application.Cashbooks.Commands;
using CashBook.Infrastructure.Cashbooks.CommandHandlers;
using CashBook.Persistence.DataContexts;
using CashBook.Persistence.Extensions;
using CashBook.Persistence.Interceptors;
using CashBook.Persistence.Repositories;
using CashBook.Persistence.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CashBook.Api.Configurations;

public static partial class HostConfigurations
{
    private static readonly ICollection<Assembly> Assemblies = Assembly
        .GetExecutingAssembly()
        .GetReferencedAssemblies()
        .Select(Assembly.Load)
        .Append(Assembly.GetExecutingAssembly())
        .ToList();
    
    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }
    
    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }
    
    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }
    
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<UpdateAuditableInterceptor>();
        
        builder.Services.AddDbContext<AppDbContext>((provider, options) => 
            options.UseSqlite(builder.Configuration.GetConnectionString("SqlLiteConnectionString"))
                .AddInterceptors(provider.GetRequiredService<UpdateAuditableInterceptor>()));
        
        return builder;
    }
    
    private static WebApplicationBuilder AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(conf 
            => {conf.RegisterServicesFromAssemblies(typeof(CreateCashbookCommandHandler).Assembly);});
        
        return builder;
    }
    
    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblies(Assemblies);
        
        return builder;
    }

    private static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICashbookRepository, CashbookRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
        
        return builder;
    }
    
    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
    
    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
    
    private static async ValueTask<WebApplication> MigrateDatabaseSchemaAsync(this WebApplication app)
    {
        var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        await serviceScopeFactory.MigrateAsync<AppDbContext>();
        
        return app;
    }
}