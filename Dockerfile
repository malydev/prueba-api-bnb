FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/ApiPruebaBnb.Api/ApiPruebaBnb.Api.csproj src/ApiPruebaBnb.Api/
COPY src/ApiPruebaBnb.Application/ApiPruebaBnb.Application.csproj src/ApiPruebaBnb.Application/
COPY src/ApiPruebaBnb.Domain/ApiPruebaBnb.Domain.csproj src/ApiPruebaBnb.Domain/
COPY src/ApiPruebaBnb.Infrastructure/ApiPruebaBnb.Infrastructure.csproj src/ApiPruebaBnb.Infrastructure/
RUN dotnet restore src/ApiPruebaBnb.Api/ApiPruebaBnb.Api.csproj

COPY src/ApiPruebaBnb.Api/ src/ApiPruebaBnb.Api/
COPY src/ApiPruebaBnb.Application/ src/ApiPruebaBnb.Application/
COPY src/ApiPruebaBnb.Domain/ src/ApiPruebaBnb.Domain/
COPY src/ApiPruebaBnb.Infrastructure/ src/ApiPruebaBnb.Infrastructure/
RUN dotnet publish src/ApiPruebaBnb.Api/ApiPruebaBnb.Api.csproj -c Release -o /app/publish --no-restore

FROM build AS migrator
RUN dotnet tool install --global dotnet-ef --version 8.0.22
ENTRYPOINT ["/root/.dotnet/tools/dotnet-ef", "database", "update", "--project", "src/ApiPruebaBnb.Infrastructure/ApiPruebaBnb.Infrastructure.csproj", "--startup-project", "src/ApiPruebaBnb.Infrastructure/ApiPruebaBnb.Infrastructure.csproj", "--configuration", "Release", "--no-build"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "ApiPruebaBnb.Api.dll"]
