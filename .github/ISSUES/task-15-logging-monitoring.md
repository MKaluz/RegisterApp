---
title: "Task 15: Implement Logging and Monitoring"
labels: ["DDD-transition", "Phase-4", "priority-medium", "infrastructure"]
---

**Priority**: Medium  
**Estimated Effort**: 2-3 hours  
**Dependencies**: Task 11

## Description
Add comprehensive logging and monitoring throughout the application without polluting business logic.

## Acceptance Criteria
- [ ] Logging behavior created for MediatR pipeline:
  - Logs command execution start
  - Logs execution duration
  - Logs success/failure
  - Logs exceptions with details
- [ ] Structured logging implemented:
  - Use ILogger<T> throughout
  - Log with context (UserId, VisitId, etc.)
  - Different log levels (Debug, Info, Warning, Error)
- [ ] Performance monitoring added:
  - Command/Query execution time
  - Database query time
  - Slow query warnings
- [ ] Security audit logging:
  - Authentication attempts
  - Authorization failures
  - Sensitive operations (password changes, deletions)
- [ ] Health checks implemented:
  - Database connectivity
  - Application status endpoint
- [ ] Configuration in appsettings.json:
  - Log levels per namespace
  - Output destinations
  - Performance thresholds

## What's Needed
- Serilog package (recommended)
- Application Insights or similar (optional)
- Understanding of structured logging

## Implementation Notes
- Use MediatR behaviors for cross-cutting concerns
- Never log sensitive data (passwords, tokens)
- Log correlation IDs for request tracking
- Consider centralized logging (Seq, ELK, etc.)
