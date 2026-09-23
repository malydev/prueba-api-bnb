using ApiPruebaBnb.Api;
using ApiPruebaBnb.Application.Services;
using ApiPruebaBnb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<PaymentService>();

var app = builder.Build();

app.UseExceptionHandler();
app.MapGroup("/api").MapControllers();

app.Run();
