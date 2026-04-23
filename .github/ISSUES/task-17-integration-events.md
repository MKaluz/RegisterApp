---
title: "Task 17: Implement Integration Events"
labels: ["DDD-transition", "Phase-5", "priority-low", "infrastructure"]
---

**Priority**: Low  
**Estimated Effort**: 4-5 hours  
**Dependencies**: Task 10

## Description
Separate domain events from integration events to prepare for future microservices architecture.

## Acceptance Criteria
- [ ] `IIntegrationEvent` interface created in Application layer
- [ ] `IIntegrationEventPublisher` interface created
- [ ] Integration events created:
  - `UserRegisteredIntegrationEvent`
  - `VisitReservedIntegrationEvent`
  - `VisitCancelledIntegrationEvent`
- [ ] Event mapping from domain events:
  - Domain event handlers map to integration events
  - Integration events have different structure (serializable)
  - Include metadata (EventId, Timestamp, Version)
- [ ] In-memory event bus implementation:
  - For current monolith
  - Can be replaced with RabbitMQ/Azure Service Bus later
- [ ] Integration event handlers:
  - Email notification handler
  - External system notification (stubbed)
- [ ] Tests covering:
  - Domain event to integration event mapping
  - Event publishing
  - Handler invocation

## What's Needed
- Understanding of integration events vs domain events
- Message broker knowledge (optional for future)
- Serialization (System.Text.Json)

## Implementation Notes
- Domain events stay within bounded context
- Integration events cross bounded contexts/services
- Integration events are immutable DTOs
- Consider idempotency for event handlers
