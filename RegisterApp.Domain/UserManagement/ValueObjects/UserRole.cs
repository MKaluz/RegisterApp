using RegisterApp.Domain.Common;

namespace RegisterApp.Domain.UserManagement.ValueObjects;

/// <summary>
/// Represents a user role with predefined valid values.
/// </summary>
public sealed class UserRole : ValueObject
{
    private static readonly HashSet<string> ValidRoles = new(StringComparer.OrdinalIgnoreCase)
    {
        "Admin",
        "User"
    };

    public static readonly UserRole Admin = new("Admin");
    public static readonly UserRole User = new("User");

    public string Value { get; }

    private UserRole(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Role cannot be empty", nameof(value));

        if (!ValidRoles.Contains(value))
            throw new ArgumentException($"Invalid role: {value}. Valid roles are: {string.Join(", ", ValidRoles)}", nameof(value));

        Value = value;
    }

    public static UserRole Create(string value) => new(value);

    public bool IsAdmin() => Value.Equals("Admin", StringComparison.OrdinalIgnoreCase);
    public bool IsUser() => Value.Equals("User", StringComparison.OrdinalIgnoreCase);

    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value.ToLowerInvariant();
    }
}
