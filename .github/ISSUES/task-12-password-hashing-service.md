---
title: "Task 12: Implement Password Hashing Service (DIP)"
labels: ["DDD-transition", "Phase-3", "priority-high", "infrastructure", "security"]
---

**Priority**: High  
**Estimated Effort**: 2-3 hours  
**Dependencies**: Task 3

## Description
Extract password hashing logic into a separate domain service following Dependency Inversion and Single Responsibility principles.

## Acceptance Criteria
- [ ] `IPasswordHasher` interface created in Domain/Common:
  - `PasswordHash Hash(Password password)`
  - `bool Verify(Password password, PasswordHash passwordHash)`
- [ ] `PasswordHasher` implementation in Infrastructure/Security:
  - Uses HMACSHA512 or BCrypt
  - Secure salt generation
  - Constant-time comparison
- [ ] User aggregate updated:
  - Inject IPasswordHasher in domain methods
  - Remove static password methods
  - Use service for hashing/verification
- [ ] Password complexity validator created:
  - Minimum 8 characters
  - At least one uppercase
  - At least one lowercase
  - At least one digit
  - At least one special character
- [ ] Tests covering:
  - Hash generation
  - Verification success/failure
  - Different passwords produce different hashes
  - Same password verified against same hash
  - Password complexity validation

## What's Needed
- System.Security.Cryptography or BCrypt.Net
- Understanding of secure password hashing
- Knowledge of DIP

## Implementation Notes
- Interface in Domain, implementation in Infrastructure
- Never log or expose password hashes
- Consider using BCrypt or Argon2 for better security
- Salt should be unique per password
