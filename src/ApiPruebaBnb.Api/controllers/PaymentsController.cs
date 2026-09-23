using ApiPruebaBnb.Application.DTOs;
using ApiPruebaBnb.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaBnb.Api.Controllers;

[ApiController]
[Route("payments")]
public class PaymentsController(PaymentService paymentService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetByCustomerId([FromQuery] string? customerId, CancellationToken cancellationToken)
    {
        var payments = await paymentService.GetByCustomerIdAsync(customerId, cancellationToken);
        return Ok(payments.Select(payment => new
        {
            payment.PaymentId,
            payment.CustomerId,
            payment.ServiceProvider,
            payment.Amount,
            payment.Currency,
            Status = payment.Status.ToString(),
            payment.CreatedAt
        }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        var payment = await paymentService.CreateAsync(request, cancellationToken);
        return Created("/api/payments", new
        {
            payment.PaymentId,
            payment.CustomerId,
            payment.ServiceProvider,
            payment.Amount,
            payment.Currency,
            Status = payment.Status.ToString(),
            payment.CreatedAt
        });
    }
}
