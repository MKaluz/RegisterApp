---
title: "Task 8: Implement Unit of Work Pattern"
labels: ["DDD-transition", "Phase-2", "priority-high", "infrastructure"]
---

**Priority**: High  
**Estimated Effort**: 3-4 hours  
**Dependencies**: Task 5

## Description
Implement Unit of Work pattern to manage transactions and ensure consistency when saving aggregates and their domain events.

## Acceptance Criteria
- [ ] `IUnitOfWork` interface created in Domain/Common with:
  - `Task<int> SaveChangesAsync(CancellationToken ct)`
  - `Task BeginTransactionAsync(CancellationToken ct)`
  - `Task CommitTransactionAsync(CancellationToken ct)`
  - `Task RollbackTransactionAsync(CancellationToken ct)`
- [ ] `UnitOfWork` implementation created in Infrastructure/Persistence with:
  - EF Core DbContext integration
  - Transaction management
  - Domain event collection and dispatching
- [ ] Domain event dispatcher created:
  - Collects events from aggregates
  - Publishes events after successful save
  - Clears events after publishing
- [ ] Integration with command handlers:
  - All handlers use UnitOfWork
  - Domain events published automatically
  - Transactions for multi-aggregate operations
- [ ] Tests covering:
  - Successful transaction commit
  - Transaction rollback on error
  - Domain event publishing
  - Multiple operations in one transaction

## What's Needed
- Understanding of Unit of Work pattern
- EF Core transaction knowledge
- Domain events dispatcher (MediatR or custom)

## Implementation Notes
```csharp
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}

// In command handler
public async Task<UserId> HandleAsync(RegisterUserCommand cmd, CancellationToken ct)
{
    var user = User.Register(...);
    await _userRepository.AddAsync(user, ct);
    await _unitOfWork.SaveChangesAsync(ct); // Saves & publishes events
    return user.Id;
}
```
