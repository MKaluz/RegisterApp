---
title: "Task 2: Create Value Objects for User Bounded Context"
labels: ["DDD-transition", "Phase-1", "priority-high", "domain"]
---

**Priority**: High  
**Estimated Effort**: 3-5 hours  
**Dependencies**: Task 1

## Description
Replace primitive types with Value Objects to enforce business rules and validation at the domain level. This addresses primitive obsession and adds domain meaning to data.

## Acceptance Criteria
- [ ] `Email` value object created with:
  - Email format validation
  - Immutability (readonly properties)
  - Equality comparison by value
  - ToString() method
- [ ] `Password` value object created with:
  - Minimum length validation (8 characters)
  - Complexity requirements (uppercase, lowercase, number, special char)
  - Hash generation method
  - No plain text storage
- [ ] `PasswordHash` value object created with:
  - Hash and Salt properties
  - Verification method
  - Immutability
- [ ] `UserRole` value object created with:
  - Predefined roles (Admin, User)
  - Role validation
  - Cannot create invalid roles
- [ ] `FullName` value object created with:
  - FirstName and LastName properties
  - Combined display name
  - Validation for non-empty names
- [ ] Unit tests for all value objects covering:
  - Valid creation scenarios
  - Invalid creation scenarios (should throw exceptions)
  - Equality comparison
  - Immutability verification

## What's Needed
- Understanding of Value Objects in DDD
- Knowledge of C# record types or immutable classes
- xUnit or NUnit for testing
- FluentAssertions (optional) for better test readability

## Implementation Notes
```csharp
// Example structure
public sealed class Email : ValueObject
{
    public string Value { get; }
    
    private Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty");
        if (!IsValidEmail(value))
            throw new ArgumentException("Invalid email format");
        Value = value;
    }
    
    public static Email Create(string value) => new Email(value);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
```
