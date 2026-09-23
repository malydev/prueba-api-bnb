FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ApiPruebaBnb.csproj ./
RUN dotnet restore ApiPruebaBnb.csproj

COPY . ./
RUN dotnet publish ApiPruebaBnb.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "ApiPruebaBnb.dll"]
