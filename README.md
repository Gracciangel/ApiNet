# Documentación de la API - Gestión de Usuarios

Esta API proporciona funcionalidades para la creación de usuarios, inicio de sesión y obtención de usuarios. Está construida en **.NET 8** y utiliza **SQL Server** para el almacenamiento de datos. La arquitectura sigue el patrón de capas, con las siguientes divisiones:

- **DML (Data Model Layer)**: Capa de modelos.
- **DAL (Data Access Layer)**: Capa de acceso a datos.
- **API**: Controladores.

También consume una biblioteca de clases **Validator** para validar los formatos de email y contraseña.

## Funcionalidades

### 1. Creación de Usuarios (Registro)

Permite registrar un nuevo usuario en el sistema.

**Endpoint:**

**Body (Request):**
```json
{
    "email": "usuario@dominio.com",
    "password": "contraseñaSegura123",
    "nombre": "Nombre del Usuario",
    "telefono": "123456789"
}
