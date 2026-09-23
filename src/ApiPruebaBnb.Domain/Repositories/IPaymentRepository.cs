using ApiPruebaBnb.Domain.Entities;

namespace ApiPruebaBnb.Domain.Repositories;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment, CancellationToken cancellationToken);
    Task<IReadOnlyList<Payment>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
}
