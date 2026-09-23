FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/ApiPruebaBnb.Api/ApiPruebaBnb.Api.csproj src/ApiPruebaBnb.Api/
RUN dotnet restore src/ApiPruebaBnb.Api/ApiPruebaBnb.Api.csproj

COPY src/ApiPruebaBnb.Api/ src/ApiPruebaBnb.Api/
RUN dotnet publish src/ApiPruebaBnb.Api/ApiPruebaBnb.Api.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "ApiPruebaBnb.Api.dll"]
