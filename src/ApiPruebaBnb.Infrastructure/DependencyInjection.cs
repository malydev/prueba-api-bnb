using System.Data.Common;
using ApiPruebaBnb.Application.Services;
using ApiPruebaBnb.Domain.Repositories;
using ApiPruebaBnb.Infrastructure.Persistence;
using ApiPruebaBnb.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaBnb.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Falta configurar ConnectionStrings:DefaultConnection.");

        services.AddScoped<DbConnection>(_ => new SqlConnection(connectionString));
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IDatabaseHealthService, SqlServerHealthService>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        return services;
    }
}
