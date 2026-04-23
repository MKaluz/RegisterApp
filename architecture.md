# RegisterApp Architecture

## Overview
RegisterApp is a medical visit registration system built with ASP.NET Core 2.2 Web API. The application follows a layered architecture pattern with clean separation of concerns.

## Architecture Diagram

```
┌─────────────────────────────────────────────────────────────────┐
│                         Client Layer                             │
│                    (Frontend Applications)                       │
└────────────────────────────┬────────────────────────────────────┘
                             │
                             │ HTTP/HTTPS
                             │ JWT Authentication
                             │
┌────────────────────────────▼────────────────────────────────────┐
│                      API Layer (ASP.NET Core)                    │
│  ┌──────────────────────────────────────────────────────────┐   │
│  │                    Controllers                           │   │
│  │  ┌───────────────┐  ┌────────────────┐  ┌───────────┐  │   │
│  │  │ UserController│  │ VisitController│  │TestControl│  │   │
│  │  │   - Auth      │  │  - CRUD Visits │  │    ler    │  │   │
│  │  │   - Register  │  │  - Reserve     │  │           │  │   │
│  │  │   - CRUD User │  │  - Cancel      │  │           │  │   │
│  │  └───────────────┘  └────────────────┘  └───────────┘  │   │
│  └─────────────┬──────────────────┬─────────────────────────┘   │
│                │                  │                              │
│  ┌─────────────▼──────────────────▼─────────────────────────┐   │
│  │              Middleware & Security                       │   │
│  │  - JWT Bearer Authentication                             │   │
│  │  - CORS Configuration                                    │   │
│  │  - Authorization (Role-based: Admin/User)                │   │
│  └──────────────────────────────────────────────────────────┘   │
└────────────────────────────┬────────────────────────────────────┘
                             │
┌────────────────────────────▼────────────────────────────────────┐
│                      Service Layer                               │
│  ┌──────────────────────────────────────────────────────────┐   │
│  │                    Business Logic                        │   │
│  │  ┌───────────────┐  ┌────────────────┐  ┌───────────┐  │   │
│  │  │  IUserService │  │ IVisitService  │  │IRepository│  │   │
│  │  │  UserService  │  │  VisitService  │  │Repository │  │   │
│  │  │               │  │                │  │  <T>      │  │   │
│  │  │- Authenticate │  │- GetAllVisits  │  │- CRUD Ops │  │   │
│  │  │- Password Hash│  │- Reserve/Cancel│  │- Generic  │  │   │
│  │  │- CRUD Users   │  │- Get Available │  │           │  │   │
│  │  └───────────────┘  └────────────────┘  └───────────┘  │   │
│  └─────────────┬──────────────────┬─────────────────────────┘   │
│                │                  │                              │
│  ┹─────────────▼──────────────────▼─────────────────────────┐   │
│  │                    AutoMapper                            │   │
│  │         (DTO ↔ Entity Mapping)                           │   │
│  └──────────────────────────────────────────────────────────┘   │
└────────────────────────────┬────────────────────────────────────┘
                             │
┌────────────────────────────▼────────────────────────────────────┐
│                    Data Access Layer                             │
│  ┌──────────────────────────────────────────────────────────┐   │
│  │              DataContext (Entity Framework Core)         │   │
│  │                                                          │   │
│  │  ┌────────┐  ┌────────┐  ┌───────────┐  ┌──────────┐  │   │
│  │  │ Users  │  │ Visits │  │VisitDates │  │VisitLoc. │  │   │
│  │  │ DbSet  │  │ DbSet  │  │  DbSet    │  │  DbSet   │  │   │
│  │  └────────┘  └────────┘  └───────────┘  └──────────┘  │   │
│  │                                                          │   │
│  │             ┌─────────────┐                              │   │
│  │             │VisitTypes   │                              │   │
│  │             │   DbSet     │                              │   │
│  │             └─────────────┘                              │   │
│  └──────────────────────────────────────────────────────────┘   │
└────────────────────────────┬────────────────────────────────────┘
                             │
                             │ Entity Framework Core
                             │ SQL Queries
                             │
┌────────────────────────────▼────────────────────────────────────┐
│                       Database Layer                             │
│  ┌──────────────────────────────────────────────────────────┐   │
│  │                   SQL Server Database                    │   │
│  │                                                          │   │
│  │  Tables:                                                 │   │
│  │  • Users (Authentication & User Management)              │   │
│  │  • Visits (Medical Visit Appointments)                   │   │
│  │  • VisitDates (Available Date Slots)                     │   │
│  │  • VisitLocations (Medical Facility Locations)           │   │
│  │  • VisitTypes (Types of Medical Visits)                  │   │
│  └──────────────────────────────────────────────────────────┘   │
└──────────────────────────────────────────────────────────────────┘
```

## Cross-Cutting Concerns

```
┌────────────────────────────────────────────────────────┐
│                 Helper Components                      │
│                                                        │
│  ┌──────────────┐  ┌────────────┐  ┌──────────────┐  │
│  │  AppSettings │  │   Swagger  │  │  AppException│  │
│  │(Config Mgmt) │  │   (API     │  │  (Error      │  │
│  │              │  │    Docs)   │  │   Handling)  │  │
│  └──────────────┘  └────────────┘  └──────────────┘  │
└────────────────────────────────────────────────────────┘
```

## Component Details

### 1. API Layer (Controllers)
- **UserController**: Handles user authentication, registration, and CRUD operations
  - `POST /user/authenticate` - User login with JWT token generation
  - `POST /user/register` - New user registration
  - `GET /user` - Get all users (Admin only)
  - `GET /user/{id}` - Get user by ID
  - `PUT /user/{id}` - Update user
  - `DELETE /user/{id}` - Delete user

- **VisitController**: Manages medical visit appointments
  - `GET /visit` - Get all visits
  - `POST /visit` - Add new visit
  - `DELETE /visit/{id}` - Delete visit (Admin only)
  - `GET /visit/available` - Show available visits
  - `GET /visit/userVisits` - Show user's visits
  - `PUT /visit/reserve/{visitId}` - Reserve a visit
  - `PUT /visit/cancel/{visitId}` - Cancel a visit

### 2. Service Layer
- **UserService**: Business logic for user management
  - Password hashing and validation
  - User authentication
  - User CRUD operations

- **VisitService**: Business logic for visit management
  - Visit availability checking
  - Visit reservation/cancellation
  - Visit CRUD operations

- **Repository<T>**: Generic repository pattern for data access

### 3. Data Access Layer
- **DataContext**: Entity Framework Core DbContext
  - Connection to SQL Server database
  - Entity mappings and migrations
  - DbSet collections for all entities

### 4. Domain Entities
- **User**: User account information with authentication
- **Visit**: Medical visit appointments with patient assignments
- **VisitDate**: Available date slots for visits
- **VisitLocation**: Medical facility locations
- **VisitType**: Categories of medical visits

### 5. Security & Authentication
- **JWT Bearer Authentication**: Token-based authentication
- **Role-based Authorization**: Admin and User roles
- **Password Security**: Hashed passwords with salt

## Technology Stack

- **Framework**: ASP.NET Core 2.2 Web API
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Authentication**: JWT Bearer Tokens
- **Mapping**: AutoMapper
- **API Documentation**: Swagger/OpenAPI
- **Dependency Injection**: Built-in ASP.NET Core DI Container

## Design Patterns

1. **Layered Architecture**: Clear separation between API, Business Logic, and Data Access
2. **Repository Pattern**: Abstraction over data access logic
3. **Dependency Injection**: Loose coupling between components
4. **DTO Pattern**: Data Transfer Objects for API communication
5. **Service Layer Pattern**: Business logic encapsulation

## Data Flow

### Authentication Flow
```
Client → UserController.Authenticate() → UserService.Authenticate()
  → DataContext → SQL Server → Verify Credentials → Generate JWT Token
  → Return Token to Client
```

### Visit Reservation Flow
```
Client (with JWT) → VisitController.ReserveVisit() → Authorization Check
  → VisitService.Update() → Repository<Visit> → DataContext
  → SQL Server → Update Visit.Patient → Return Success
```

## Security Considerations

- All endpoints except `/user/authenticate` and `/user/register` require authentication
- Role-based authorization protects admin-only operations
- Passwords are never stored in plain text (hashed with salt)
- JWT tokens expire after 7 days
- CORS is configured to allow cross-origin requests
