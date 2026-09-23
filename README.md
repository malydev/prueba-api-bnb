# API Prueba BNB

API mínima en .NET 8 con SQL Server 2022, ambos ejecutados con Docker Compose.

## Iniciar

1. Crea `.env` a partir de `.env.example` y cambia `MSSQL_SA_PASSWORD` por una contraseña fuerte (SQL Server exige mayúsculas, minúsculas, números y símbolos).
2. Ejecuta `docker compose up --build -d`.
3. Comprueba la API en <http://localhost:8080/> y <http://localhost:8080/health>.

Compose espera a que SQL Server acepte conexiones, crea la base `ApiPruebaBnb` si no existe y luego inicia la API. Los datos persisten en el volumen `sqlserver_data`. La cadena de conexión llega a la API mediante `ConnectionStrings__DefaultConnection`; el proyecto queda listo para agregar acceso a datos según se desarrolle el sistema.

SQL Server se publica en `localhost:1433` para conectar desde el equipo anfitrión. Los puertos se pueden cambiar con `API_PORT` y `SQL_PORT` en `.env`. Desde otros contenedores se utiliza `sqlserver:1433`.

Para apagar: `docker compose down`. Para borrar también la base de datos: `docker compose down -v`.

**Nota:** la imagen oficial de SQL Server es `linux/amd64`. En equipos ARM (por ejemplo, Apple Silicon) Docker debe poder emular esa arquitectura; SQL Server puede no funcionar correctamente bajo emulación.
