using ApiPruebaBnb.Application.DTOs;

namespace ApiPruebaBnb.Application.Validators;

public static class PaymentValidator
{
    public static void Validate(CreatePaymentRequest request)
    {
        if (request.CustomerId == Guid.Empty)
            throw new RequestValidationException("El ID de cliente es invalido");

        if (string.IsNullOrWhiteSpace(request.ServiceProvider))
            throw new RequestValidationException("El provedor de servicios es obligatorio");

        if (request.ServiceProvider.Trim().Length > 200)
            throw new RequestValidationException("El provedor de servicios no puede tener más de 200 caracteres");

        if (request.Amount <= 0)
            throw new RequestValidationException("El monto debe ser mayor que 0");

        if (request.Amount > 1500)
            throw new RequestValidationException("El monto no puede superar los 1500");

        if (string.IsNullOrWhiteSpace(request.Currency))
            throw new RequestValidationException("La moneda es obligatoria");

        var currency = request.Currency.Trim().ToUpperInvariant();

        if (currency.Any(character => character is < 'A' or > 'Z'))
            throw new RequestValidationException("La moneda debe contener unicamente letras");


        if (currency == "USD" ||
            currency == "DOLAR" ||
            currency == "US$" ||
            currency == "$" ||
            currency == "US")
            throw new RequestValidationException("No se permite dolares.");

    }
}
