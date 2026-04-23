# RegisterApp.Api

## Current Status
This project is configured with .NET 8 and API Controllers. The structure is ready for implementation.

## ⚠️ Important Notes

### Authorization Not Yet Configured
The controllers have `[Authorize]` attributes, but authentication/authorization services are not yet configured in `Program.cs`. This means:
- Endpoints with `[AllowAnonymous]` will work
- Endpoints requiring authorization will return 401 Unauthorized

To enable authorization, you need to:
1. Add authentication services (e.g., JWT)
2. Configure authorization policies
3. Add `app.UseAuthentication()` before `app.UseAuthorization()`

Example:
```csharp
// In Program.cs
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => { /* configure JWT */ });

// Then before app.UseAuthorization():
app.UseAuthentication();
app.UseAuthorization();
```

## Next Steps
1. Implement business logic in Application layer
2. Add Entity Framework Core for data persistence
3. Implement JWT authentication
4. Add AutoMapper for DTO mapping
5. Implement proper error handling and validation
6. Add unit and integration tests

See [API-DOCUMENTATION.md](API-DOCUMENTATION.md) for endpoint details.
