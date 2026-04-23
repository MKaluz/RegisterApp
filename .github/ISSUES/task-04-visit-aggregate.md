---
title: "Task 4: Create Visit Aggregate Root"
labels: ["DDD-transition", "Phase-1", "priority-high", "domain"]
---

**Priority**: High  
**Estimated Effort**: 4-6 hours  
**Dependencies**: Task 2

## Description
Create a rich Visit aggregate that encapsulates scheduling logic, availability rules, and reservation management.

## Acceptance Criteria
- [ ] Value objects created:
  - `TimeSlot` (StartTime, EndTime, Duration validation)
  - `VisitType` (Type name, description)
  - `PatientId` (User reference)
  - `Location` (Location details)
- [ ] `Visit` aggregate root created with:
  - Private setters
  - Use of value objects
  - Status enum (Available, Reserved, Completed, Cancelled)
- [ ] Business methods implemented:
  - `Schedule(TimeSlot, VisitType, Location)` - Factory method
  - `Reserve(PatientId)` - Reserves visit for patient
  - `Cancel()` - Cancels reservation
  - `Complete()` - Marks as completed
  - `IsAvailable()` - Checks if can be reserved
  - `IsInFuture()` - Validation helper
- [ ] Domain events created:
  - `VisitScheduledDomainEvent`
  - `VisitReservedDomainEvent`
  - `VisitCancelledDomainEvent`
  - `VisitCompletedDomainEvent`
- [ ] Business rules enforced:
  - Cannot reserve past visits
  - Cannot reserve already reserved visits
  - Cannot cancel completed visits
  - Visit duration must be positive
  - End time must be after start time
- [ ] Unit tests covering:
  - Visit creation with valid/invalid data
  - Reservation scenarios (success, already reserved, in past)
  - Cancellation scenarios
  - Status transitions
  - Domain event raising

## What's Needed
- Understanding of aggregate boundaries
- Knowledge of state machines for visit status
- DateTime handling best practices
- Testing framework

## Implementation Notes
- Visit is aggregate root for scheduling bounded context
- Status transitions should be explicit
- Cannot reference User directly (use PatientId)
- Time slot validation is critical
