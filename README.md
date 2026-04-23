# RegisterApp - Domain-Driven Design Architecture

## Overview

RegisterApp is a medical appointment registration system built following Domain-Driven Design (DDD) principles with a clear separation of concerns across multiple architectural layers.

## Architecture

This application follows a **Clean Architecture** approach with DDD principles, organized into four main layers:

### 1. Domain Layer (`RegisterApp.Domain`)
**Purpose**: Contains the core business logic and domain models.

**Characteristics**:
- Has no dependencies on other layers (except framework)
- Contains pure business logic
- Defines interfaces for repositories (dependency inversion)

**Structure**:
```
RegisterApp.Domain/
├── UserManagement/              # Bounded Context for user operations
│   ├── Aggregates/              # Aggregate roots (e.g., User)
│   ├── ValueObjects/            # Immutable value objects (e.g., Email, Password)
│   ├── DomainEvents/            # Domain events (e.g., UserRegistered)
│   ├── DomainServices/          # Domain services for complex operations
│   └── Repositories/            # Repository interfaces
├── VisitScheduling/             # Bounded Context for visit management
│   ├── Aggregates/              # Aggregate roots (e.g., Visit)
│   ├── ValueObjects/            # Value objects (e.g., VisitDate, Location)
│   ├── DomainEvents/            # Domain events (e.g., VisitScheduled)
│   ├── DomainServices/          # Domain services
│   └── Repositories/            # Repository interfaces
└── Common/                      # Shared kernel (common abstractions)
```

**Bounded Contexts**:
- **UserManagement**: Handles user registration, authentication, and profile management
- **VisitScheduling**: Manages medical visit appointments, availability, and scheduling

### 2. Application Layer (`RegisterApp.Application`)
**Purpose**: Orchestrates domain logic and defines use cases.

**Characteristics**:
- References Domain layer only
- Contains application-specific business rules
- Implements CQRS pattern (Commands and Queries)
- Defines DTOs for data transfer
- Coordinates transactions via Unit of Work

**Typical Structure** (to be implemented):
```
RegisterApp.Application/
├── Commands/                    # Write operations (Create, Update, Delete)
│   ├── Handlers/
│   └── Validators/
├── Queries/                     # Read operations
│   ├── Handlers/
│   └── DTOs/
├── Common/
│   ├── Interfaces/              # Application service interfaces
│   └── Mappings/                # Object mapping profiles
└── Behaviors/                   # Cross-cutting concerns (validation, logging)
```

### 3. Infrastructure Layer (`RegisterApp.Infrastructure`)
**Purpose**: Implements technical concerns and external dependencies.

**Characteristics**:
- References Domain and Application layers
- Implements repository interfaces from Domain
- Contains data access code (Entity Framework Core)
- Handles external service integrations
- Implements authentication and authorization

**Typical Structure** (to be implemented):
```
RegisterApp.Infrastructure/
├── Persistence/
│   ├── Configurations/          # EF Core entity configurations
│   ├── Repositories/            # Repository implementations
│   └── DataContext.cs
├── Authentication/              # JWT, Identity providers
├── ExternalServices/            # Third-party integrations
└── Logging/                     # Logging implementations
```

### 4. API/Presentation Layer (`RegisterApp.Api`)
**Purpose**: Exposes the application via HTTP REST API.

**Characteristics**:
- References Application and Infrastructure layers
- Contains controllers for HTTP endpoints
- Handles request/response serialization
- Implements API versioning and documentation (Swagger)
- Configures dependency injection

**Structure**:
```
RegisterApp.Api/
├── Controllers/                 # REST API endpoints
├── Middleware/                  # Custom middleware (error handling, etc.)
├── Filters/                     # Action filters
└── Program.cs & Startup.cs      # Application configuration
```

## Dependency Flow

```
┌─────────────────────────────────────┐
│         API Layer                   │
│     (RegisterApp.Api)               │
└──────────────┬──────────────────────┘
               │
               ↓
┌──────────────────────────────────────┐
│    Infrastructure Layer               │
│  (RegisterApp.Infrastructure)         │
└──────────────┬───────────────────────┘
               │
               ↓
┌──────────────────────────────────────┐
│    Application Layer                  │
│  (RegisterApp.Application)            │
└──────────────┬───────────────────────┘
               │
               ↓
┌──────────────────────────────────────┐
│      Domain Layer                     │
│   (RegisterApp.Domain)                │
│   - No external dependencies          │
└───────────────────────────────────────┘
```

**Key Principle**: Dependencies always point inward. The Domain layer is at the center and has no knowledge of outer layers.

## Key DDD Concepts

### Bounded Contexts
Logical boundaries within the domain model that define specific areas of the business:
- **UserManagement**: User accounts, authentication, authorization
- **VisitScheduling**: Medical appointments, availability, locations, visit types

### Aggregates
Clusters of domain objects treated as a single unit:
- **User Aggregate**: User entity with related value objects (Email, Password, Role)
- **Visit Aggregate**: Visit entity with related value objects (VisitDate, Location, Type)

### Value Objects
Immutable objects defined by their attributes rather than identity:
- Email, Password, UserRole (UserManagement)
- VisitDate, VisitLocation, VisitType (VisitScheduling)

### Domain Events
Events that capture important business occurrences:
- UserRegistered, UserAuthenticated (UserManagement)
- VisitScheduled, VisitCancelled (VisitScheduling)

### Repository Pattern
Abstractions for data access, defined in Domain, implemented in Infrastructure:
- IUserRepository, IVisitRepository

## SOLID Principles

This architecture follows SOLID principles:

- **S**ingle Responsibility: Each layer and class has one reason to change
- **O**pen/Closed: Open for extension, closed for modification
- **L**iskov Substitution: Abstractions can be replaced with implementations
- **I**nterface Segregation: Interfaces are specific and focused
- **D**ependency Inversion: High-level modules don't depend on low-level modules

## Technology Stack

- **.NET 8.0**: Target framework for all projects
- **ASP.NET Core**: Web API framework
- **Entity Framework Core**: ORM for data access (to be configured)
- **Swagger/OpenAPI**: API documentation

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- SQL Server (for data persistence)
- Visual Studio 2022 or VS Code with C# extensions

### Building the Solution

```bash
# Restore dependencies
dotnet restore

# Build all projects
dotnet build

# Run the API
dotnet run --project RegisterApp.Api
```

### Running Tests

```bash
# Run all tests
dotnet test
```

## Project Status

This is the foundational structure for the DDD refactoring of RegisterApp. The following phases are planned:

1. ✅ **Phase 1: Foundation** - Project structure setup (Current)
2. ⏳ **Phase 2: Domain Layer** - Implement aggregates, value objects, and domain events
3. ⏳ **Phase 3: Application Layer** - Implement CQRS with commands and queries
4. ⏳ **Phase 4: Infrastructure Layer** - Implement repositories and data access
5. ⏳ **Phase 5: API Layer** - Refactor controllers to use CQRS

## Migration from Legacy Code

The `FinalProjectApi` project contains the legacy monolithic implementation. It will remain in the solution during the transition period for reference and gradual migration.

## Contributing

When contributing to this project:
1. Follow the established DDD patterns and folder structure
2. Keep domain logic in the Domain layer
3. Use value objects instead of primitives where appropriate
4. Define repository interfaces in Domain, implement in Infrastructure
5. Follow the SOLID principles
6. Write unit tests for domain logic
7. Write integration tests for infrastructure concerns

## Documentation

- [DDD Transition Guide](./DDD-TRANSITION-GUIDE.md) - Comprehensive implementation plan
- [Architecture Details](./architecture.md) - Current system architecture
- [Task Issues](./.github/ISSUES/) - Detailed implementation tasks

## License

[Add license information here]

## Contact

[Add contact information here]
