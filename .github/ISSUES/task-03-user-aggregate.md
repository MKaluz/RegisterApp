---
title: "Task 3: Create User Aggregate Root"
labels: ["DDD-transition", "Phase-1", "priority-high", "domain"]
---

**Priority**: High  
**Estimated Effort**: 4-6 hours  
**Dependencies**: Task 2

## Description
Transform the anemic User entity into a rich aggregate root with business logic, invariant enforcement, and domain events.

## Acceptance Criteria
- [ ] `User` aggregate root created in `Domain/UserManagement/Aggregates/` with:
  - Private setters for all properties
  - Public methods for all business operations
  - Use of value objects (Email, FullName, UserRole, PasswordHash)
  - Domain event raising capability
- [ ] Business methods implemented:
  - `Register(Email, FullName, Password, UserRole)` - Factory method
  - `Authenticate(Password)` - Returns success/failure
  - `ChangePassword(Password oldPassword, Password newPassword)`
  - `UpdateProfile(FullName)`
  - `PromoteToAdmin()` - Changes role
  - `DemoteToUser()` - Changes role
- [ ] Domain events created:
  - `UserRegisteredDomainEvent`
  - `UserAuthenticatedDomainEvent`
  - `PasswordChangedDomainEvent`
  - `UserRoleChangedDomainEvent`
- [ ] Invariant validation:
  - Email must be unique (enforced by repository)
  - Password must meet complexity requirements
  - User cannot have null or invalid properties
- [ ] Base `AggregateRoot<TId>` class created with:
  - Id property
  - Domain events collection
  - AddDomainEvent/ClearDomainEvents methods
  - Created/Modified timestamps
- [ ] Unit tests for User aggregate covering:
  - Successful user registration
  - Authentication success/failure scenarios
  - Password change with validation
  - Role changes
  - Domain event raising

## What's Needed
- Understanding of Aggregate Root pattern
- Knowledge of domain events
- Password hashing library (System.Security.Cryptography)
- Testing framework

## Implementation Notes
- Aggregate root should encapsulate all business rules
- No public setters - state changes through methods
- All operations should validate invariants
- Domain events communicate what happened
