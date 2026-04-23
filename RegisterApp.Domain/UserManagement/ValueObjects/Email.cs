using System.Text.RegularExpressions;
using RegisterApp.Domain.Common;

namespace RegisterApp.Domain.UserManagement.ValueObjects;

/// <summary>
/// Represents an email address value object with validation and immutability.
/// </summary>
public sealed class Email : ValueObject
{
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; }

    private Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty", nameof(value));

        if (!IsValidEmail(value))
            throw new ArgumentException("Invalid email format", nameof(value));

        Value = value.ToLowerInvariant().Trim();
    }

    public static Email Create(string value) => new(value);

    private static bool IsValidEmail(string email)
    {
        return EmailRegex.IsMatch(email);
    }

    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
