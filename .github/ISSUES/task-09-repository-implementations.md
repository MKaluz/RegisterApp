---
title: "Task 9: Implement Repository Concrete Classes"
labels: ["DDD-transition", "Phase-3", "priority-high", "infrastructure"]
---

**Priority**: High  
**Estimated Effort**: 4-6 hours  
**Dependencies**: Task 5, Task 8

## Description
Implement repository interfaces in the Infrastructure layer using Entity Framework Core, including mapping between domain entities and persistence models.

## Acceptance Criteria
- [ ] EF Core entities created in `Infrastructure/Persistence/Entities/`:
  - `UserEntity` (mirrors User aggregate)
  - `VisitEntity` (mirrors Visit aggregate)
  - Separate from domain entities
- [ ] EF Core configuration classes created:
  - `UserEntityConfiguration`
  - `VisitEntityConfiguration`
  - Value object conversions configured
  - Table names, indexes, constraints
- [ ] `UserRepository` implemented in `Infrastructure/Persistence/Repositories/`:
  - Implements `IUserRepository`
  - Maps between UserEntity and User aggregate
  - All CRUD operations
  - Optimized queries with proper includes
- [ ] `VisitRepository` implemented:
  - Implements `IVisitRepository`
  - Maps between VisitEntity and Visit aggregate
  - All CRUD operations
  - Optimized queries with filtering
- [ ] Mapping extensions created:
  - `UserEntity.ToDomain()` → User
  - `User.ToEntity()` → UserEntity
  - `VisitEntity.ToDomain()` → Visit
  - `Visit.ToEntity()` → VisitEntity
- [ ] Integration tests covering:
  - Save and retrieve aggregates
  - Mapping correctness
  - Query methods
  - Concurrent access scenarios

## What's Needed
- EF Core knowledge
- Understanding of persistence models vs domain models
- Integration testing setup (In-memory database or test container)

## Implementation Notes
- Never expose EF entities outside Infrastructure layer
- Always map to domain aggregates
- Use separate EF entities to avoid polluting domain
- Value objects should be stored as owned entities or separate tables
