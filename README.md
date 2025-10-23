# Sistema de Gestión de Clínica

Sistema de gestión integral para clínicas médicas desarrollado con arquitectura hexagonal, que permite administrar pacientes, citas médicas, órdenes, facturación y recursos clínicos.

## Introducción al Proyecto

Este sistema está diseñado para facilitar la gestión diaria de una clínica médica, proporcionando diferentes interfaces según el rol del usuario:

- **Admin**: Gestión de pacientes, citas y facturación
- **Doctor**: Órdenes médicas, historiales clínicos, recetas
- **Nurse**: Visitas de enfermería, registro de atención
- **RRHH**: Gestión de usuarios del sistema
- **Support**: Gestión de inventario de recursos clínicos

## Arquitectura del Proyecto

El sistema está organizado en 3 capas principales:

- **Domain**: Modelos de negocio (Patient, User, Order, Appointment, etc.)
- **Application**: Casos de uso específicos del sistema
- **Infrastructure**: Conexión a PostgreSQL y configuración

## Flujo de Datos

### Flujo Exitoso:
1. Usuario interactúa con Windows Forms → `Form1.cs`
2. Input Adapter valida y construye objetos → `AdminInputs`, `DoctorInputs`, etc.
3. Use Case coordina la operación → `AdminUseCase`, `DoctorUseCase`, etc.
4. Domain Service ejecuta reglas de negocio → `CreatePatient`, `CreateOrder`, etc.
5. Port (interfaz) define qué operaciones hacer → `IPatientPort`, `IOrderPort`, etc.
6. Adapter de salida ejecuta en BD → `PostgresPatientPort`, `PostgresOrderPort`, etc.
7. Respuesta exitosa regresa por el mismo camino hasta la UI

### Flujo con Error:
1. Si hay error de validación → Exception lanzada en Input Adapter
2. Si hay error de reglas de negocio → Exception lanzada en Domain Service
3. Si hay error de BD → Exception lanzada en Postgres Adapter
4. Exception se propaga hacia arriba por todas las capas
5. UI captura la excepción y muestra mensaje al usuario

## Estructura de Carpetas

```
Clinica Herramientas 2/
├── Domain/
│   ├── Model/                # Patient, User, Order, Appointment, etc.
│   ├── Ports/                # IPatientPort, IOrderPort, etc.
│   └── Services/             # CreatePatient, CreateOrder, etc.
├── Application/
│   ├── Adapters/Input/       # AdminInputs, DoctorInputs, Builders, Validators
│   └── UseCases/             # AdminUseCase, DoctorUseCase, etc.
├── Infrastructure/
│   ├── Adapters/Output/Persistence/  # PostgresPatientPort, ClinicaDbContext
│   └── Config/               # Config, ConfigFactory, AdminConfig, etc.
├── Migrations/               # Migraciones de Entity Framework
├── Program.cs                # Punto de entrada
├── Form1.cs                  # Interfaz de usuario
└── appsettings.json          # Configuración de conexión a BD
```

## Tecnologías Utilizadas

- **.NET 8.0** - Framework principal
- **C# 12** - Lenguaje de programación
- **Windows Forms** - Interfaz gráfica de usuario
- **Entity Framework Core 9.0.10** - ORM para acceso a datos
- **PostgreSQL** - Base de datos relacional
- **Npgsql 9.0.4** - Proveedor de PostgreSQL para .NET

## Configuración y Ejecución

### Requisitos:
- .NET 8.0 SDK
- PostgreSQL instalado y corriendo
- Visual Studio 2022 o superior (recomendado)

### Pasos:
1. Clonar el repositorio
2. Configurar cadena de conexión en `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "ClinicaDb": "Host=localhost;Database=clinica;Username=tu_usuario;Password=tu_password"
     }
   }
   ```
3. Ejecutar migraciones: `dotnet ef database update`
4. Ejecutar la aplicación: `dotnet run` o F5 en Visual Studio

## Patrones de Diseño Implementados

- **Hexagonal Architecture** (Ports & Adapters)
- **Factory Pattern** - `PortsFactory`, `ConfigFactory`
- **Builder Pattern** - `PatientBuilder`, `OrderBuilder`, etc.
- **Repository Pattern** - Ports como repositorios
- **Dependency Injection** - Configuración en `Config.cs`

## Modelos Principales

- **Patient**: Información del paciente, contacto de emergencia, seguro médico
- **User**: Usuarios del sistema con diferentes roles
- **Appointment**: Citas médicas programadas
- **Order**: Órdenes médicas con items específicos
- **MedicalRecord**: Historial clínico de pacientes
- **Invoice**: Facturación de servicios
- **ClinicalResource**: Recursos clínicos (medicamentos, procedimientos, ayudas diagnósticas)

## Configuración de Roles

El sistema maneja 5 tipos de usuarios con permisos específicos:

1. **AdminConfig**: Acceso completo a gestión de pacientes, citas y facturación
2. **DoctorConfig**: Creación de órdenes médicas y historiales clínicos
3. **NurseConfig**: Registro de visitas de enfermería
4. **RRHHConfig**: Gestión de usuarios del sistema
5. **SupportConfig**: Administración de inventario de recursos clínicos

Cada configuración incluye sus respectivos servicios, casos de uso, builders y adaptadores de entrada específicos para su rol.
