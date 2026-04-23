---
title: "Task 14: Add Validation Pipeline (OCP)"
labels: ["DDD-transition", "Phase-4", "priority-medium", "application"]
---

**Priority**: Medium  
**Estimated Effort**: 3-4 hours  
**Dependencies**: Task 6

## Description
Implement a validation pipeline using FluentValidation that allows adding validators without modifying command handlers (Open-Closed Principle).

## Acceptance Criteria
- [ ] FluentValidation package installed
- [ ] Base validation infrastructure created:
  - `ICommandValidator<TCommand>` interface
  - Validation behavior for MediatR pipeline
  - ValidationException class
- [ ] Validators created for all commands:
  - `RegisterUserCommandValidator`
  - `AuthenticateUserCommandValidator`
  - `ScheduleVisitCommandValidator`
  - `ReserveVisitCommandValidator`
  - Each with comprehensive rules
- [ ] Validation rules implemented:
  - Required fields
  - Email format
  - Password complexity
  - Date validations (no past dates)
  - Business rule validations
- [ ] Validation pipeline configured:
  - Runs before command handler
  - Collects all validation errors
  - Throws ValidationException with all errors
  - Returns 400 Bad Request with error details
- [ ] Tests for validators:
  - Valid commands pass
  - Invalid commands fail with correct errors
  - Multiple validation errors collected
  - Pipeline integration

## What's Needed
- FluentValidation package
- FluentValidation.DependencyInjectionExtensions
- MediatR.Extensions.FluentValidation (or custom behavior)

## Implementation Notes
```csharp
public class RegisterUserCommandValidator 
    : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
            
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches(@"[A-Z]").WithMessage("Must contain uppercase")
            .Matches(@"[a-z]").WithMessage("Must contain lowercase")
            .Matches(@"\d").WithMessage("Must contain digit");
    }
}
```
