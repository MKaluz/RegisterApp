---
title: "Task 6: Implement CQRS Pattern - Commands"
labels: ["DDD-transition", "Phase-2", "priority-high", "application"]
---

**Priority**: High  
**Estimated Effort**: 5-7 hours  
**Dependencies**: Task 5

## Description
Implement Command Query Responsibility Segregation (CQRS) pattern for write operations. Create commands, command handlers, and establish the command processing pipeline.

## Acceptance Criteria
- [ ] Base command infrastructure created in Application layer:
  - `ICommand` marker interface
  - `ICommand<TResult>` interface for commands with return values
  - `ICommandHandler<TCommand>` interface
  - `ICommandHandler<TCommand, TResult>` interface
- [ ] User management commands created:
  - `RegisterUserCommand` (Email, Password, FirstName, LastName)
  - `AuthenticateUserCommand` (Email, Password)
  - `ChangePasswordCommand` (UserId, OldPassword, NewPassword)
  - `UpdateUserProfileCommand` (UserId, FirstName, LastName)
  - `DeleteUserCommand` (UserId)
- [ ] Visit scheduling commands created:
  - `ScheduleVisitCommand` (StartTime, EndTime, Type, Location)
  - `ReserveVisitCommand` (VisitId, PatientId)
  - `CancelVisitReservationCommand` (VisitId, PatientId)
  - `CompleteVisitCommand` (VisitId)
- [ ] Command handlers implemented for all commands:
  - Validation logic
  - Aggregate retrieval from repository
  - Business method invocation
  - Repository save
  - Domain event publishing
- [ ] Command results created:
  - Success/Failure results
  - Error messages
  - Validation errors collection
- [ ] Unit tests for command handlers covering:
  - Successful command execution
  - Validation failures
  - Business rule violations
  - Repository interactions (mocked)

## What's Needed
- MediatR package (optional, for command bus)
- Understanding of CQRS pattern
- Validation library (FluentValidation recommended)
- Mocking framework (Moq, NSubstitute)

## Implementation Notes
```csharp
// Example structure
public record RegisterUserCommand(
    string Email, 
    string Password, 
    string FirstName, 
    string LastName) : ICommand<UserId>;

public class RegisterUserCommandHandler 
    : ICommandHandler<RegisterUserCommand, UserId>
{
    private readonly IUserRepository _repository;
    
    public async Task<UserId> HandleAsync(
        RegisterUserCommand command, 
        CancellationToken ct)
    {
        // Validation
        // Create aggregate
        // Save to repository
        // Return result
    }
}
```
