using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Features.Booking;
using Batch4.Api.CinemaTicketBookingSystem.Features.Movie;
using Batch4.Api.CinemaTicketBookingSystem.Features.MovieDetailed;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
        services.AddScoped<DA_Booking>();
        services.AddScoped<DA_Movie>();
        services.AddScoped<DA_MovieDetailed>();
        return services;
    }
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<BL_Booking>();
        services.AddScoped<BL_Movie>();
        services.AddScoped<BL_MovieDetailed>();
        return services;
    }

    public static IServiceCollection AddDbConnection(this IServiceCollection services, WebApplicationBuilder builder) 
    {
        string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        }, ServiceLifetime.Transient, ServiceLifetime.Transient);
        builder.Services.AddScoped<IDbConnection>(n => new SqlConnection(connectionString));
        return services;
    }
}
