var builder = WebApplication.CreateBuilder(args);

if (string.IsNullOrWhiteSpace(builder.Configuration.GetConnectionString("DefaultConnection")))
{
    throw new InvalidOperationException("Falta configurar ConnectionStrings:DefaultConnection.");
}

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new { message = "API Prueba BNB" }));
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();
