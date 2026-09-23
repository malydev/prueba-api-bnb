namespace ApiPruebaBnb.Application.Services;

public interface IDatabaseHealthService
{
    Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default);
}
