---
title: "Task 13: Implement Authentication Service (SRP & DIP)"
labels: ["DDD-transition", "Phase-3", "priority-high", "infrastructure", "security"]
---

**Priority**: High  
**Estimated Effort**: 3-4 hours  
**Dependencies**: Task 12

## Description
Create a dedicated authentication service following Single Responsibility Principle, separating JWT generation from user management.

## Acceptance Criteria
- [ ] `IAuthenticationService` interface created in Application layer:
  - `Task<AuthenticationResult> AuthenticateAsync(Email, Password, CancellationToken)`
  - `string GenerateToken(User user)`
  - `ClaimsPrincipal ValidateToken(string token)`
- [ ] `IJwtTokenGenerator` interface created in Application layer:
  - `string GenerateToken(UserId, Email, UserRole, DateTime expiration)`
  - `TokenValidationResult ValidateToken(string token)`
- [ ] `JwtTokenGenerator` implementation in Infrastructure:
  - JWT token generation with claims
  - Token validation
  - Configuration from appsettings
- [ ] `AuthenticationService` implementation in Application:
  - Coordinates authentication flow
  - Uses IUserRepository, IPasswordHasher, IJwtTokenGenerator
  - Returns success/failure result
  - Raises authentication events
- [ ] `AuthenticationResult` class created:
  - Success/Failure status
  - JWT token (if successful)
  - User info (Id, Email, Role)
  - Error message (if failed)
- [ ] Tests covering:
  - Successful authentication
  - Invalid credentials
  - Token generation
  - Token validation

## What's Needed
- System.IdentityModel.Tokens.Jwt
- Microsoft.AspNetCore.Authentication.JwtBearer
- Understanding of JWT tokens

## Implementation Notes
- Authentication is application service, not domain service
- JWT generation is infrastructure concern
- Keep domain clean of authentication details
- Token should include user id and role as claims
