using ApiPruebaBnb.Application.DTOs;
using ApiPruebaBnb.Application.Validators;
using ApiPruebaBnb.Domain.Entities;
using ApiPruebaBnb.Domain.Repositories;

namespace ApiPruebaBnb.Application.Services;

public class PaymentService(IPaymentRepository paymentRepository)
{
    public async Task<Payment> CreateAsync(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        PaymentValidator.Validate(request);

        var payment = new Payment
        {
            CustomerId = request.CustomerId,
            ServiceProvider = request.ServiceProvider!.Trim(),
            Amount = request.Amount,
            Currency = request.Currency!.Trim().ToUpperInvariant()
        };

        await paymentRepository.AddAsync(payment, cancellationToken);
        return payment;
    }

    public Task<IReadOnlyList<Payment>> GetByCustomerIdAsync(string? customerId, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(customerId, out var id) || id == Guid.Empty)
            throw new RequestValidationException("CustomerId es obligatorio y debe ser un UUID válido.");

        return paymentRepository.GetByCustomerIdAsync(id, cancellationToken);
    }
}
