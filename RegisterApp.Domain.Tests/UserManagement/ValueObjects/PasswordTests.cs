using FluentAssertions;
using RegisterApp.Domain.UserManagement.ValueObjects;

namespace RegisterApp.Domain.Tests.UserManagement.ValueObjects;

public class PasswordTests
{
    [Theory]
    [InlineData("Password123!")]
    [InlineData("SecureP@ss1")]
    [InlineData("MyP@ssw0rd")]
    [InlineData("Complex1ty!")]
    public void Create_WithValidPassword_ShouldSucceed(string validPassword)
    {
        // Act
        var password = Password.Create(validPassword);

        // Assert
        password.Should().NotBeNull();
        password.Value.Should().Be(validPassword);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_WithEmptyPassword_ShouldThrowArgumentException(string? emptyPassword)
    {
        // Act
        Action act = () => Password.Create(emptyPassword!);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Password cannot be empty*");
    }

    [Theory]
    [InlineData("Short1!")]
    [InlineData("Pass1!")]
    public void Create_WithPasswordTooShort_ShouldThrowArgumentException(string shortPassword)
    {
        // Act
        Action act = () => Password.Create(shortPassword);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*must be at least 8 characters long*");
    }

    [Fact]
    public void Create_WithoutUpperCase_ShouldThrowArgumentException()
    {
        // Act
        Action act = () => Password.Create("password123!");

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*must contain at least one uppercase letter*");
    }

    [Fact]
    public void Create_WithoutLowerCase_ShouldThrowArgumentException()
    {
        // Act
        Action act = () => Password.Create("PASSWORD123!");

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*must contain at least one lowercase letter*");
    }

    [Fact]
    public void Create_WithoutDigit_ShouldThrowArgumentException()
    {
        // Act
        Action act = () => Password.Create("Password!");

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*must contain at least one number*");
    }

    [Fact]
    public void Create_WithoutSpecialChar_ShouldThrowArgumentException()
    {
        // Act
        Action act = () => Password.Create("Password123");

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*must contain at least one special character*");
    }

    [Fact]
    public void GenerateHash_ShouldCreatePasswordHash()
    {
        // Arrange
        var password = Password.Create("Password123!");

        // Act
        var hash = password.GenerateHash();

        // Assert
        hash.Should().NotBeNull();
        hash.Hash.Should().NotBeEmpty();
        hash.Salt.Should().NotBeEmpty();
    }

    [Fact]
    public void GenerateHash_ShouldCreateDifferentHashesForSamePassword()
    {
        // Arrange
        var password1 = Password.Create("Password123!");
        var password2 = Password.Create("Password123!");

        // Act
        var hash1 = password1.GenerateHash();
        var hash2 = password2.GenerateHash();

        // Assert - Hashes should be different because salts are different
        hash1.Should().NotBe(hash2);
        hash1.Salt.Should().NotEqual(hash2.Salt);
    }

    [Fact]
    public void Equals_WithSameValue_ShouldReturnTrue()
    {
        // Arrange
        var password1 = Password.Create("Password123!");
        var password2 = Password.Create("Password123!");

        // Act & Assert
        password1.Should().Be(password2);
        (password1 == password2).Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentValue_ShouldReturnFalse()
    {
        // Arrange
        var password1 = Password.Create("Password123!");
        var password2 = Password.Create("DifferentPass1!");

        // Act & Assert
        password1.Should().NotBe(password2);
        (password1 != password2).Should().BeTrue();
    }

    [Fact]
    public void Value_ShouldBeImmutable()
    {
        // Arrange
        var password = Password.Create("Password123!");
        var originalValue = password.Value;

        // Act
        var value = password.Value;

        // Assert
        value.Should().Be(originalValue);
        password.Value.Should().Be("Password123!");
    }
}
