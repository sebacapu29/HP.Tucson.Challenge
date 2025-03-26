# Challenge Tucson API

## Descripción
Este es un proyecto realizado con tecnologías .Net 8, con la finalidad de gestionar las reservas del restaurant Tucson.

## Estructura del Proyecto
- **HP.Tucson.Domain**: Contiene las entidades del dominio y las interfaces de los repositorios y servicios.
- **HP.Tucson.Application**: Contiene la lógica de la aplicación.
- **HP.Tucson.Infrastructure**: Contiene las conexiones a base de datos o sistemas externos.
- **HP.Tucson.Tests**: Contiene las pruebas unitarias.
- **HP.Tucson.API**: Aplicación Web API para probar la funcionalidad.

## Bibliotecas de Terceros
- **Moq**: Para la creación de mocks en las pruebas unitarias.
- **xUnit**: Framework de pruebas unitarias.
- **StackExchange.Redis** Sistema de guardado en cache de Redis.
- **Mediatr** Para implementar CQRS.
- **Swashbuckle.AspNetCore** Swagger para documentación de API.

## Requisitos para ejecutar la aplicación (Recomendado)
- Clonar el proyecto
- Tener instalado Docker ([Docker Page](https://docs.docker.com/desktop/setup/install/windows-install/) )
- Levantar Redis local con Docker : `docker run --name redis-server -d -p 6379:6379 redis`
- Ejecutar la API con Visual Studio 2022 o ejecutar el comando `dotnet run --launch-profile Desarrollo` o `dotnet run --launch-profile Desarrollo`