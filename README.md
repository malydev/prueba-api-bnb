<div align="center">

# API Prueba BNB

![C#](https://img.shields.io/badge/-C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/-ASP.NET%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/-SQL%20Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)
![Docker](https://img.shields.io/badge/-Docker-2496ED?style=flat-square&logo=docker&logoColor=white)

</div>

## Descripción

Ejemplo de una API basica para registrar y consultar pagos de servicios basicos(agua, electricidad, telecomunicaciones) de clientes

## Instrucciones para iniciar

Se debe ejecuta estos pasos **en este orden**, desde la carpeta del proyecto

1. realizar copia de `.env` y configura `MSSQL_SA_PASSWORD`, `DB_NAME` y `DB_USER` 

   ```bash
   cp .env.example .env
   ```

2. Levanta la API y SQL Server:

   ```bash
   docker compose up --build -d
   ```

3. Crea la base de datos y las migraciones de las tablas :

   ```bash
   docker compose run --rm --build migrator
   ```

4. Comprueba la conexión de la API con la base:

   ```bash
   curl -i http://localhost:8080/health
   ```

   Debe responder `HTTP 200` con `{"status":"ok"}`
   Si se configuraste otro `API_PORT` se debe cambair en la url

## Detener

```bash
docker compose down
```

Para eliminar tambien los datos almacenados en SQL Server:

```bash
docker compose down -v
```
