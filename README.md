# Desarrollo de Prueba técnica para empresa HelpPeople (Parte Backend)

## Tecnologías usadas
  .net 6.0
  c#

- ### Nugets
- Microsoft.EntityFrameworkCore.SqlServer 7.0
- Microsoft.EntityFrameworkCore.Tools 7.0
- AutoMapper 12.01
- CsvHelper 33.0.0

## Generación de modelos y conexión a base de datos

1. crear una base de datos sql server con el nombre HelpPeople
2. Ejecutar la siguiente consulta
   
   CREATE TABLE Persona (
    IdPersona BIGINT NOT NULL PRIMARY KEY IDENTITY(1000,1),  
    Nombre VARCHAR(55) NOT NULL,  
    Apellido VARCHAR(55) NOT NULL,  
    CorreoElectronico VARCHAR(60) NOT NULL,  
    TipoDocumento VARCHAR(2),  
    NroDocumento INT NOT NULL,  
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
  );

3. En la consola del administrador de paquetes, ejecutar el siguiente comando para la conexión a la base de datos según las credenciales locales
   Scaffold-DbContext "Server=localhost;Database=HelpPeople;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

