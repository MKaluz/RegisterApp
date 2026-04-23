using System.Security.Cryptography;
using System.Text;
using RegisterApp.Domain.Common;

namespace RegisterApp.Domain.UserManagement.ValueObjects;

/// <summary>
/// Represents a hashed password with salt for secure storage.
/// </summary>
public sealed class PasswordHash : ValueObject
{
    public byte[] Hash { get; }
    public byte[] Salt { get; }

    private PasswordHash(byte[] hash, byte[] salt)
    {
        if (hash == null || hash.Length == 0)
            throw new ArgumentException("Hash cannot be empty", nameof(hash));

        if (salt == null || salt.Length == 0)
            throw new ArgumentException("Salt cannot be empty", nameof(salt));

        // Create defensive copies to ensure immutability
        Hash = (byte[])hash.Clone();
        Salt = (byte[])salt.Clone();
    }

    public static PasswordHash Create(byte[] hash, byte[] salt) => new(hash, salt);

    /// <summary>
    /// Verifies if the provided password matches this hash.
    /// </summary>
    public bool Verify(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        using var hmac = new HMACSHA512(Salt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        
        return computedHash.SequenceEqual(Hash);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Convert.ToBase64String(Hash);
        yield return Convert.ToBase64String(Salt);
    }
}
