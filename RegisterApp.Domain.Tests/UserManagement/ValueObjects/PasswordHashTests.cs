using FluentAssertions;
using RegisterApp.Domain.UserManagement.ValueObjects;

namespace RegisterApp.Domain.Tests.UserManagement.ValueObjects;

public class PasswordHashTests
{
    [Fact]
    public void Create_WithValidHashAndSalt_ShouldSucceed()
    {
        // Arrange
        var hash = new byte[] { 1, 2, 3, 4, 5 };
        var salt = new byte[] { 6, 7, 8, 9, 10 };

        // Act
        var passwordHash = PasswordHash.Create(hash, salt);

        // Assert
        passwordHash.Should().NotBeNull();
        passwordHash.Hash.Should().Equal(hash);
        passwordHash.Salt.Should().Equal(salt);
    }

    [Fact]
    public void Create_WithEmptyHash_ShouldThrowArgumentException()
    {
        // Arrange
        var emptyHash = Array.Empty<byte>();
        var salt = new byte[] { 1, 2, 3 };

        // Act
        Action act = () => PasswordHash.Create(emptyHash, salt);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Hash cannot be empty*");
    }

    [Fact]
    public void Create_WithNullHash_ShouldThrowArgumentException()
    {
        // Arrange
        byte[]? nullHash = null;
        var salt = new byte[] { 1, 2, 3 };

        // Act
        Action act = () => PasswordHash.Create(nullHash!, salt);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Hash cannot be empty*");
    }

    [Fact]
    public void Create_WithEmptySalt_ShouldThrowArgumentException()
    {
        // Arrange
        var hash = new byte[] { 1, 2, 3 };
        var emptySalt = Array.Empty<byte>();

        // Act
        Action act = () => PasswordHash.Create(hash, emptySalt);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Salt cannot be empty*");
    }

    [Fact]
    public void Create_WithNullSalt_ShouldThrowArgumentException()
    {
        // Arrange
        var hash = new byte[] { 1, 2, 3 };
        byte[]? nullSalt = null;

        // Act
        Action act = () => PasswordHash.Create(hash, nullSalt!);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Salt cannot be empty*");
    }

    [Fact]
    public void Verify_WithCorrectPassword_ShouldReturnTrue()
    {
        // Arrange
        var password = Password.Create("Password123!");
        var passwordHash = password.GenerateHash();

        // Act
        var result = passwordHash.Verify("Password123!");

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Verify_WithIncorrectPassword_ShouldReturnFalse()
    {
        // Arrange
        var password = Password.Create("Password123!");
        var passwordHash = password.GenerateHash();

        // Act
        var result = passwordHash.Verify("WrongPassword1!");

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Verify_WithEmptyPassword_ShouldReturnFalse(string? emptyPassword)
    {
        // Arrange
        var password = Password.Create("Password123!");
        var passwordHash = password.GenerateHash();

        // Act
        var result = passwordHash.Verify(emptyPassword!);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WithSameHashAndSalt_ShouldReturnTrue()
    {
        // Arrange
        var hash = new byte[] { 1, 2, 3, 4, 5 };
        var salt = new byte[] { 6, 7, 8, 9, 10 };
        var passwordHash1 = PasswordHash.Create(hash, salt);
        var passwordHash2 = PasswordHash.Create(hash, salt);

        // Act & Assert
        passwordHash1.Should().Be(passwordHash2);
        (passwordHash1 == passwordHash2).Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentHash_ShouldReturnFalse()
    {
        // Arrange
        var hash1 = new byte[] { 1, 2, 3, 4, 5 };
        var hash2 = new byte[] { 1, 2, 3, 4, 6 };
        var salt = new byte[] { 6, 7, 8, 9, 10 };
        var passwordHash1 = PasswordHash.Create(hash1, salt);
        var passwordHash2 = PasswordHash.Create(hash2, salt);

        // Act & Assert
        passwordHash1.Should().NotBe(passwordHash2);
        (passwordHash1 != passwordHash2).Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentSalt_ShouldReturnFalse()
    {
        // Arrange
        var hash = new byte[] { 1, 2, 3, 4, 5 };
        var salt1 = new byte[] { 6, 7, 8, 9, 10 };
        var salt2 = new byte[] { 6, 7, 8, 9, 11 };
        var passwordHash1 = PasswordHash.Create(hash, salt1);
        var passwordHash2 = PasswordHash.Create(hash, salt2);

        // Act & Assert
        passwordHash1.Should().NotBe(passwordHash2);
        (passwordHash1 != passwordHash2).Should().BeTrue();
    }

    [Fact]
    public void HashAndSalt_ShouldBeImmutable()
    {
        // Arrange
        var hash = new byte[] { 1, 2, 3, 4, 5 };
        var salt = new byte[] { 6, 7, 8, 9, 10 };
        var passwordHash = PasswordHash.Create(hash, salt);

        // Act - Try to modify original arrays
        hash[0] = 99;
        salt[0] = 99;

        // Assert - PasswordHash should retain original values
        passwordHash.Hash[0].Should().Be(1);
        passwordHash.Salt[0].Should().Be(6);
    }

    [Fact]
    public void GetHashCode_WithSameValue_ShouldReturnSameHashCode()
    {
        // Arrange
        var hash = new byte[] { 1, 2, 3, 4, 5 };
        var salt = new byte[] { 6, 7, 8, 9, 10 };
        var passwordHash1 = PasswordHash.Create(hash, salt);
        var passwordHash2 = PasswordHash.Create(hash, salt);

        // Act & Assert
        passwordHash1.GetHashCode().Should().Be(passwordHash2.GetHashCode());
    }
}
