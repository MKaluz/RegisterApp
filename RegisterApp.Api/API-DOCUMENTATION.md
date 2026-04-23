# RegisterApp API Documentation

## Overview
This is a .NET 8 Web API for user registration and visit scheduling using API controllers.

## Technologies
- .NET 8
- ASP.NET Core Web API
- Swagger/OpenAPI
- RESTful architecture

## Running the Application

### Build
```bash
dotnet build RegisterApp.slnx
```

### Run
```bash
cd RegisterApp.Api
dotnet run
```

The API will be available at:
- HTTPS: https://localhost:7185
- HTTP: http://localhost:5185
- Swagger UI: https://localhost:7185/swagger

## API Endpoints

### Health
- `GET /api/health` - Check API health status

### Users
- `POST /api/users/authenticate` - Authenticate user and get token
- `POST /api/users/register` - Register a new user
- `GET /api/users` - Get all users (requires authentication)
- `GET /api/users/{id}` - Get user by ID (requires authentication)
- `PUT /api/users/{id}` - Update user (requires authentication)
- `DELETE /api/users/{id}` - Delete user (requires authentication)

### Visits
- `GET /api/visits` - Get all visits
- `POST /api/visits` - Create a new visit
- `GET /api/visits/available` - Get available visits
- `GET /api/visits/user` - Get user's visits (requires authentication)
- `PUT /api/visits/{visitId}/reserve` - Reserve a visit (requires authentication)
- `PUT /api/visits/{visitId}/cancel` - Cancel a visit reservation (requires authentication)
- `DELETE /api/visits/{id}` - Delete a visit (requires authentication)

## Project Structure
```
RegisterApp.Api/
├── Controllers/           # API Controllers
│   ├── HealthController.cs
│   ├── UsersController.cs
│   └── VisitsController.cs
├── Models/               # DTOs
│   ├── UserDto.cs
│   └── VisitDto.cs
├── Program.cs            # Application entry point
└── appsettings.json      # Configuration
```

## Testing
Use the `RegisterApp.Api.http` file with REST Client extension in VS Code or Visual Studio to test the endpoints.

## Next Steps
The current implementation provides endpoint stubs. To complete the application:
1. Implement business logic in Application layer
2. Add Entity Framework Core for data persistence
3. Implement JWT authentication
4. Add AutoMapper for DTO mapping
5. Implement proper error handling and validation
6. Add unit and integration tests
