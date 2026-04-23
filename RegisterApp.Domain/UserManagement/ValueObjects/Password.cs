using System.Security.Cryptography;
using System.Text;
using RegisterApp.Domain.Common;

namespace RegisterApp.Domain.UserManagement.ValueObjects;

/// <summary>
/// Represents a password value object with complexity validation.
/// Does not store plain text passwords - use for validation and hash generation only.
/// </summary>
public sealed class Password : ValueObject
{
    private const int MinimumLength = 8;

    public string Value { get; }

    private Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Password cannot be empty", nameof(value));

        if (value.Length < MinimumLength)
            throw new ArgumentException($"Password must be at least {MinimumLength} characters long", nameof(value));

        if (!HasUpperCase(value))
            throw new ArgumentException("Password must contain at least one uppercase letter", nameof(value));

        if (!HasLowerCase(value))
            throw new ArgumentException("Password must contain at least one lowercase letter", nameof(value));

        if (!HasDigit(value))
            throw new ArgumentException("Password must contain at least one number", nameof(value));

        if (!HasSpecialChar(value))
            throw new ArgumentException("Password must contain at least one special character", nameof(value));

        Value = value;
    }

    public static Password Create(string value) => new(value);

    /// <summary>
    /// Generates a password hash with salt.
    /// </summary>
    public PasswordHash GenerateHash()
    {
        using var hmac = new HMACSHA512();
        var salt = hmac.Key;
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Value));
        return PasswordHash.Create(hash, salt);
    }

    private static bool HasUpperCase(string password) => password.Any(char.IsUpper);
    private static bool HasLowerCase(string password) => password.Any(char.IsLower);
    private static bool HasDigit(string password) => password.Any(char.IsDigit);
    private static bool HasSpecialChar(string password) => 
        password.Any(c => char.IsPunctuation(c) || char.IsSymbol(c));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
