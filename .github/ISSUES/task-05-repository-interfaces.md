---
title: "Task 5: Define Repository Interfaces in Domain"
labels: ["DDD-transition", "Phase-1", "priority-high", "domain"]
---

**Priority**: High  
**Estimated Effort**: 2-3 hours  
**Dependencies**: Task 3, Task 4

## Description
Define repository interfaces in the domain layer following DDD principles. Repositories should work with aggregates, not entities.

## Acceptance Criteria
- [ ] `IUserRepository` interface created in `Domain/UserManagement/Repositories/` with:
  - `Task<User> GetByIdAsync(UserId id, CancellationToken ct)`
  - `Task<User> GetByEmailAsync(Email email, CancellationToken ct)`
  - `Task<bool> IsEmailUniqueAsync(Email email, CancellationToken ct)`
  - `Task AddAsync(User user, CancellationToken ct)`
  - `Task UpdateAsync(User user, CancellationToken ct)`
  - `Task DeleteAsync(UserId id, CancellationToken ct)`
- [ ] `IVisitRepository` interface created in `Domain/VisitScheduling/Repositories/` with:
  - `Task<Visit> GetByIdAsync(VisitId id, CancellationToken ct)`
  - `Task<IReadOnlyList<Visit>> GetAvailableVisitsAsync(DateTime from, DateTime to, CancellationToken ct)`
  - `Task<IReadOnlyList<Visit>> GetUserVisitsAsync(PatientId patientId, CancellationToken ct)`
  - `Task AddAsync(Visit visit, CancellationToken ct)`
  - `Task UpdateAsync(Visit visit, CancellationToken ct)`
  - `Task DeleteAsync(VisitId id, CancellationToken ct)`
- [ ] Base `IRepository<TAggregate, TId>` interface created with common methods
- [ ] Repositories return domain objects (aggregates), not DTOs
- [ ] All methods are async with CancellationToken support
- [ ] Methods use value objects for parameters (Email, UserId, etc.)
- [ ] No SaveChanges() method (Unit of Work pattern will handle this)

## What's Needed
- Understanding of Repository pattern in DDD
- Knowledge of async/await patterns
- Familiarity with Unit of Work pattern

## Implementation Notes
- Repositories are interfaces in Domain, implementations in Infrastructure
- Work with aggregate roots only
- No IQueryable leaking from repository
- Specific query methods instead of generic Find()
