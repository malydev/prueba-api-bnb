using ApiPruebaBnb.Application.Validators;
using Microsoft.AspNetCore.Diagnostics;

namespace ApiPruebaBnb.Api;

public class ApiExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var validationError = exception is RequestValidationException;

        await Results.Problem(
            statusCode: validationError ? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError,
            title: validationError ? "Solicitud inválida" : "Error interno del servidor",
            detail: validationError ? exception.Message : "No se pudo procesar la solicitud."
        ).ExecuteAsync(httpContext);

        return true;
    }
}
