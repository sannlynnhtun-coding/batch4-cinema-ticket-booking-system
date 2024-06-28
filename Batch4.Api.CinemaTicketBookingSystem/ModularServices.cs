using Batch4.Api.CinemaTicketBookingSystem.Database;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Batch4.Api.CinemaTicketBookingSystem;

public static class ModularServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder) 
    {
        services.AddDataAccess();
        services.AddBusinessLogic();
        services.AddDbConnection(builder);
        return services;
    }

    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        return services;
    }
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddDbConnection(this IServiceCollection services, WebApplicationBuilder builder) 
    {
        string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        }, ServiceLifetime.Transient, ServiceLifetime.Transient);
        services.AddScoped<DbConnection>(n => new SqlConnection(connectionString));
        return services;
    }
}
