using ApiPruebaBnb.Domain.Entities;
using ApiPruebaBnb.Domain.Repositories;
using ApiPruebaBnb.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaBnb.Infrastructure.Repositories;

public class PaymentRepository(AppDbContext dbContext) : IPaymentRepository
{
    public async Task AddAsync(Payment payment, CancellationToken cancellationToken)
    {
        dbContext.Payments.Add(payment);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Payment>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
    {
        return await dbContext.Payments.AsNoTracking()
            .Where(payment => payment.CustomerId == customerId)
            .OrderByDescending(payment => payment.CreatedAt)
            .ThenByDescending(payment => payment.PaymentId)
            .ToListAsync(cancellationToken);
    }
}
