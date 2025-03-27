# Clean Architecture Template

## Overview

This is a .NET template for creating projects using Clean Architecture principles.

## Features

- Clean Architecture structure following best practices.
- Clear separation of concerns.
- Modular and scalable design for easy maintainability.
- Preconfigured API documentation with **Swagger** and **Scalar**.

## Prerequisites

- .NET 9.0 SDK

## Installation

To install the template, run the following command:

```bash
dotnet new install BrayanHenao.CleanArchitecture.Template
```

## Usage

Create a new project using the template:

```bash
dotnet new clean-arch -n YourProjectName
```

## Project Structure

The project follows Clean Architecture principles, organizing code into distinct layers:

### `Api/`
This layer serves as the entry point for the application and contains:
- **Controllers/**: Defines API endpoints.
- **appsettings.json**: Application configuration settings.
- **Program.cs**: The main entry point to configure and start the application.

### `Application/`
Contains business logic and application services:
- **Commands/**: Handles operations that modify data (Create, Update, Delete).
- **Queries/**: Handles operations that retrieve data.
- **DTO/**: Data Transfer Objects used for request/response.
- **Exceptions/**: Custom exception classes.
- **Interfaces/**: Contracts for application services and repositories.
- **Profiles/**: Automapper profiles for mapping entities to DTOs.
- **Services/**: Implementation of application logic.

### `Domain/`
Defines the core business logic:
- **Entities/**: Business entities and aggregates.

### `Infrastructure/`
Handles external concerns like database access and APIs:
- **Api/**: External API integrations.
- **Context/**: Database context and EF Core configurations.
- **EntityConfiguration/**: Database entity configurations.
- **Migrations/**: EF Core migrations.
- **Repositories/**: Data access repositories.
- **UnitOfWork/**: Transaction management.

### `Host/`
Handles application startup and configuration:
- **Extensions/**: Extension methods for application setup.
  - `ApplicationBuilderExtensions.cs`: Middleware pipeline configuration.
  - `ServiceCollectionExtensions.cs`: Dependency injection configurations.
- **Middlewares/**: Custom middleware for request processing.
  - `GlobalExceptionHandler.cs`: Centralized exception handling.
- **HostExtensions.cs**: Additional host configurations.

### `Shared/`
Contains utilities shared across all layers:
- **Constants/**: Application-wide constant values.
- **Helpers/**: Utility classes and helper methods.

## API Documentation

This template includes built-in API documentation through **Swagger** and **Scalar**:

- **Swagger UI:** Accessible at `/swagger` for interactive API exploration.
- **Scalar UI:** Available at `/scalar`, providing an alternative and modern documentation interface.

## License

This project is licensed under the MIT License.

