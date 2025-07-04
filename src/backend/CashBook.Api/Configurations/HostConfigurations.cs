namespace CashBook.Api.Configurations;

public static partial class HostConfigurations
{
    public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
    {
        builder
            .AddDevTools()
            .AddExposers()
            .AddMappers()
            .AddMediator()
            .AddValidators()
            .AddServices()
            .AddPersistence();
        
        return builder;
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .UseExposers();
        
        await app.MigrateDatabaseSchemaAsync();
        
        return app;
    }
}