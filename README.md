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

Desde la carpeta del proyecto:

1. Si todavía no tienes `.env`, crealo copiando el ejemplo (si ya existe, conserva el tuyo y pasa al paso siguiente):

   ```bash
   cp .env.example .env
   ```

2. Abre `.env` con tu editor y configura estos valores:

   ```dotenv
   MSSQL_SA_PASSWORD=DevOnly_Strong123!
   DB_NAME=ApiPruebaBnb
   DB_USER=sa
   API_PORT=8080
   SQL_PORT=1433
   ```

3. Construye e inicia los contenedores:

   ```bash
   docker compose up --build -d --remove-orphans
   ```

4. Comprueba el estado y la API:

   ```bash
   docker compose ps -a
   curl http://localhost:8080/health
   ```

   `/health` responde `{"status":"ok"}`. SQL Server este disponible

## Detener

```bash
docker compose down
```

Para eliminar tambien los datos almacenados en SQL Server:

```bash
docker compose down -v
```
