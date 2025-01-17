# Class Library Guia Juegos

### Dependencias
```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Tools
```
```
Microsoft.EntityFrameworkCore.Design
```
> [!WARNING]  
> Para una migracion exitosa EntityFrameworkCore.Tools debe estar en el projecto que contienen las Entidades que representan la Base de datos, y EntityFrameworkCore.Design debe estar en el projecto en donde esta la ruta de conexion a la Base de Datos.

### Structura de clases
```mermaid
graph TD;
    Juego --> Personaje
    Juego --> Fuente
    Juego --> FondoImg
    Juego --> Guia

    Guia --> GuiaUsuario
    Guia --> Aventura

    Aventura --> AventuraUsuario
    Aventura --> AventuraImg   
    ;
```

### JSon
```
```

## Clase de Conexion y Migracion
### Clase DbContext
```
public class GuiaJuegosDbContext : DbContext
{
    public GuiaJuegosDbContext(DbContextOptions<GuiaJuegosDbContext> options) : base(options)
    {
    }

    public DbSet<GJJuegoEntity> GJ_Juegos { get; set; }
}
```
### Use NuGet Console
* Generic Migration
```
Add-Migration Inicial
Update-DataBase
```
* Specific Migration
```
Add-Migration -Context GuiaJuegosDbContext Inicial
Update-DataBase -Context GuiaJuegosDbContext
```
> [!WARNING]  
> These commands must be used in the project that contains the entities that represent the Database.

## Services
```
```

