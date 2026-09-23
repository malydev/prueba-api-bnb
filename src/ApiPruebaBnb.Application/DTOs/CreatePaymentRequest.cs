namespace ApiPruebaBnb.Application.DTOs;

public record CreatePaymentRequest(
    Guid CustomerId,
    string? ServiceProvider,
    decimal Amount,
    string? Currency);
