using RegisterApp.Domain.Common;

namespace RegisterApp.Domain.UserManagement.ValueObjects;

/// <summary>
/// Represents a person's full name with first and last name components.
/// </summary>
public sealed class FullName : ValueObject
{
    public string FirstName { get; }
    public string LastName { get; }

    private FullName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty", nameof(lastName));

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }

    public static FullName Create(string firstName, string lastName) => new(firstName, lastName);

    /// <summary>
    /// Gets the full display name in "FirstName LastName" format.
    /// </summary>
    public string DisplayName => $"{FirstName} {LastName}";

    public override string ToString() => DisplayName;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}
