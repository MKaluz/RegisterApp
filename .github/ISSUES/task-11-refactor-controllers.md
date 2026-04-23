---
title: "Task 11: Refactor API Controllers to Use CQRS"
labels: ["DDD-transition", "Phase-4", "priority-high", "api"]
---

**Priority**: High  
**Estimated Effort**: 4-6 hours  
**Dependencies**: Task 6, Task 7

## Description
Refactor existing controllers to use CQRS commands and queries instead of direct service calls. Controllers become thin orchestration layer.

## Acceptance Criteria
- [ ] `UsersController` refactored:
  - Inject command/query mediator or handlers
  - POST /authenticate → AuthenticateUserCommand
  - POST /register → RegisterUserCommand
  - GET / → GetAllUsersQuery
  - GET /{id} → GetUserByIdQuery
  - PUT /{id} → UpdateUserProfileCommand
  - DELETE /{id} → DeleteUserCommand
  - Remove direct service dependencies
- [ ] `VisitsController` refactored:
  - POST / → ScheduleVisitCommand
  - GET /available → GetAvailableVisitsQuery
  - GET /userVisits → GetUserVisitsQuery
  - PUT /reserve/{id} → ReserveVisitCommand
  - PUT /cancel/{id} → CancelVisitReservationCommand
  - DELETE /{id} → DeleteVisitCommand (Admin only)
- [ ] Request/Response DTOs updated:
  - API DTOs in Api project
  - Map to Commands/Queries
  - Proper validation attributes
- [ ] Controller actions are thin (5-10 lines max):
  - Create command/query from request
  - Send to handler
  - Map result to response
  - Return appropriate HTTP status
- [ ] Error handling middleware created:
  - Global exception handler
  - Domain exception → 400 Bad Request
  - Not found → 404
  - Validation errors → 400 with details
- [ ] API tests updated to work with new structure

## What's Needed
- MediatR package for command/query dispatching
- Understanding of controller refactoring
- HTTP status code best practices

## Implementation Notes
```csharp
[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] RegisterRequest request)
{
    var command = new RegisterUserCommand(
        request.Email, 
        request.Password, 
        request.FirstName, 
        request.LastName);
    
    var userId = await _mediator.Send(command);
    
    return CreatedAtAction(nameof(GetById), new { id = userId }, null);
}
```
