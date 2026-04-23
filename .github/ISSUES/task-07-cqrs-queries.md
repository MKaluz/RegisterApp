---
title: "Task 7: Implement CQRS Pattern - Queries"
labels: ["DDD-transition", "Phase-2", "priority-high", "application"]
---

**Priority**: High  
**Estimated Effort**: 4-6 hours  
**Dependencies**: Task 6

## Description
Implement the query side of CQRS pattern. Create optimized read models and query handlers that bypass the domain layer for read operations.

## Acceptance Criteria
- [ ] Base query infrastructure created:
  - `IQuery<TResult>` interface
  - `IQueryHandler<TQuery, TResult>` interface
- [ ] Read model DTOs created in Application layer:
  - `UserDto` (Id, Email, FirstName, LastName, Role)
  - `UserListDto` (subset for list views)
  - `VisitDto` (Id, StartTime, EndTime, Type, Status, PatientId)
  - `VisitListDto` (subset for list views)
  - `AvailableVisitDto` (optimized for availability display)
- [ ] User queries created:
  - `GetUserByIdQuery` (UserId) → UserDto
  - `GetUserByEmailQuery` (Email) → UserDto
  - `GetAllUsersQuery` (PageNumber, PageSize) → PagedResult<UserListDto>
- [ ] Visit queries created:
  - `GetVisitByIdQuery` (VisitId) → VisitDto
  - `GetAvailableVisitsQuery` (DateFrom, DateTo, Location) → List<AvailableVisitDto>
  - `GetUserVisitsQuery` (PatientId) → List<VisitDto>
  - `GetAllVisitsQuery` (PageNumber, PageSize) → PagedResult<VisitListDto>
- [ ] Query handlers implemented:
  - Direct database access (can use Dapper for performance)
  - No aggregate loading
  - Optimized queries with projections
  - Pagination support
- [ ] Unit tests for query handlers covering:
  - Successful query execution
  - Empty results
  - Pagination
  - Filtering

## What's Needed
- Dapper package (optional, for performance)
- AutoMapper or manual mapping
- Understanding of read model optimization
- Pagination library (optional)

## Implementation Notes
- Queries bypass domain layer and read directly from database
- Read models are optimized DTOs, not domain entities
- Can use different database/storage for queries (optional)
- Consider caching for frequently accessed data
