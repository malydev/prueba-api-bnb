using ApiPruebaBnb.Api;
using ApiPruebaBnb.Application.Services;
using ApiPruebaBnb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.DocumentFilter<ApiPrefixDocumentFilter>());
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<PaymentService>();

var app = builder.Build();

app.UseExceptionHandler();
app.UseSwagger(options => options.RouteTemplate = "api/swagger/{documentName}/swagger.json");
app.UseSwaggerUI(options =>
{
    options.RoutePrefix = "api/swagger";
    options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "API Prueba BNB v1");
});
app.MapGroup("/api").MapControllers();

app.Run();
