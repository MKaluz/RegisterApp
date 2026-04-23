---
title: "Task 16: Add Pagination and Filtering (LSP)"
labels: ["DDD-transition", "Phase-5", "priority-low", "application"]
---

**Priority**: Low  
**Estimated Effort**: 2-3 hours  
**Dependencies**: Task 7

## Description
Implement generic pagination and filtering that works with all queries without modifying individual handlers (Liskov Substitution Principle).

## Acceptance Criteria
- [ ] Generic pagination classes created:
  - `PagedQuery<T>` base class (Page, PageSize, SortBy, SortOrder)
  - `PagedResult<T>` class (Items, TotalCount, PageNumber, TotalPages)
  - `QuerySpecification<T>` for filtering
- [ ] Query base classes updated to support pagination:
  - `GetAllUsersQuery` extends `PagedQuery<UserListDto>`
  - `GetAllVisitsQuery` extends `PagedQuery<VisitListDto>`
- [ ] Filtering support added:
  - Date range filtering for visits
  - Role filtering for users
  - Status filtering for visits
  - Search by name/email
- [ ] Sorting support added:
  - Generic sort by any property
  - Ascending/descending
  - Default sorting for each query
- [ ] Repository methods updated:
  - Support for specifications
  - Efficient pagination (skip/take)
  - Count queries for total records
- [ ] API controllers updated:
  - Accept pagination parameters
  - Return pagination metadata
  - Link headers for next/previous pages

## What's Needed
- Understanding of specification pattern
- LINQ knowledge for dynamic sorting/filtering
- HTTP pagination best practices

## Implementation Notes
```csharp
public record PagedQuery<T>
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string SortBy { get; init; }
    public SortOrder SortOrder { get; init; }
}

public record PagedResult<T>
{
    public IReadOnlyList<T> Items { get; init; }
    public int TotalCount { get; init; }
    public int PageNumber { get; init; }
    public int TotalPages { get; init; }
    public bool HasPrevious => PageNumber > 1;
    public bool HasNext => PageNumber < TotalPages;
}
```
