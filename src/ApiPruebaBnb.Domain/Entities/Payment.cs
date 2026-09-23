namespace ApiPruebaBnb.Domain.Entities;

public class Payment
{
    public Guid PaymentId { get; set; }
    public Guid CustomerId { get; set; }
    public string ServiceProvider { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public PaymentStatus Status { get; private set; } = PaymentStatus.pendiente;
    public DateTimeOffset CreatedAt { get; private set; }
}
