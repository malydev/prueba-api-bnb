using System.Data.Common;
using ApiPruebaBnb.Application.Services;

namespace ApiPruebaBnb.Infrastructure.Persistence;

public class SqlServerHealthService(DbConnection connection) : IDatabaseHealthService
{
    public async Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await connection.OpenAsync(cancellationToken);
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT 1";
            return (int?)await command.ExecuteScalarAsync(cancellationToken) == 1;
        }
        catch (DbException)
        {
            return false;
        }
    }
}
