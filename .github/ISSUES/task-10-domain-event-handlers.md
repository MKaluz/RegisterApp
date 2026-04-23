---
title: "Task 10: Implement Domain Event Handlers"
labels: ["DDD-transition", "Phase-3", "priority-medium", "application"]
---

**Priority**: Medium  
**Estimated Effort**: 3-5 hours  
**Dependencies**: Task 3, Task 4, Task 8

## Description
Create domain event handlers to react to business events, enabling loose coupling and side effects without polluting aggregates.

## Acceptance Criteria
- [ ] Event handler infrastructure created:
  - `IDomainEventHandler<TEvent>` interface
  - Event dispatcher/publisher (MediatR integration or custom)
- [ ] User domain event handlers created:
  - `UserRegisteredEventHandler` - Sends welcome email (stubbed)
  - `PasswordChangedEventHandler` - Logs security event
  - `UserAuthenticatedEventHandler` - Updates last login timestamp
- [ ] Visit domain event handlers created:
  - `VisitReservedEventHandler` - Sends confirmation to patient
  - `VisitCancelledEventHandler` - Sends cancellation notification
  - `VisitCompletedEventHandler` - Triggers follow-up workflow
- [ ] Event publishing integrated in UnitOfWork:
  - Collect events from all aggregates
  - Publish after successful SaveChanges
  - Ensure events published in correct order
- [ ] Tests for event handlers:
  - Handler invocation on event
  - Multiple handlers for same event
  - Error handling in handlers
  - Event publishing flow

## What's Needed
- MediatR package (recommended) or custom event bus
- Understanding of domain events pattern
- Email service interface (for notifications)

## Implementation Notes
- Domain events are not integration events
- Handlers should be fast (async operations queued)
- Consider eventual consistency
- Handlers can call external services (via interfaces)
