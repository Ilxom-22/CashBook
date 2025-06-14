using CashBook.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace CashBook.Api.Configurations;

public static partial class HostConfigurations
{
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlite(builder.Configuration.GetConnectionString("SqlLiteConnectionString")));
        
        return builder;
    }
}