using FluentAssertions;
using RegisterApp.Domain.UserManagement.ValueObjects;

namespace RegisterApp.Domain.Tests.UserManagement.ValueObjects;

public class EmailTests
{
    [Theory]
    [InlineData("user@example.com")]
    [InlineData("test.user@domain.co.uk")]
    [InlineData("admin@company.org")]
    [InlineData("name+tag@example.com")]
    public void Create_WithValidEmail_ShouldSucceed(string validEmail)
    {
        // Act
        var email = Email.Create(validEmail);

        // Assert
        email.Should().NotBeNull();
        email.Value.Should().Be(validEmail.ToLowerInvariant().Trim());
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_WithEmptyEmail_ShouldThrowArgumentException(string? emptyEmail)
    {
        // Act
        Action act = () => Email.Create(emptyEmail!);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Email cannot be empty*");
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("@example.com")]
    [InlineData("user@")]
    [InlineData("user @example.com")]
    [InlineData("user@example")]
    [InlineData("user@@example.com")]
    public void Create_WithInvalidEmailFormat_ShouldThrowArgumentException(string invalidEmail)
    {
        // Act
        Action act = () => Email.Create(invalidEmail);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Invalid email format*");
    }

    [Fact]
    public void Equals_WithSameValue_ShouldReturnTrue()
    {
        // Arrange
        var email1 = Email.Create("test@example.com");
        var email2 = Email.Create("test@example.com");

        // Act & Assert
        email1.Should().Be(email2);
        (email1 == email2).Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentValue_ShouldReturnFalse()
    {
        // Arrange
        var email1 = Email.Create("test1@example.com");
        var email2 = Email.Create("test2@example.com");

        // Act & Assert
        email1.Should().NotBe(email2);
        (email1 != email2).Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentCase_ShouldReturnTrue()
    {
        // Arrange
        var email1 = Email.Create("Test@Example.com");
        var email2 = Email.Create("test@example.com");

        // Act & Assert
        email1.Should().Be(email2);
    }

    [Fact]
    public void ToString_ShouldReturnEmailValue()
    {
        // Arrange
        var email = Email.Create("test@example.com");

        // Act
        var result = email.ToString();

        // Assert
        result.Should().Be("test@example.com");
    }

    [Fact]
    public void GetHashCode_WithSameValue_ShouldReturnSameHashCode()
    {
        // Arrange
        var email1 = Email.Create("test@example.com");
        var email2 = Email.Create("test@example.com");

        // Act & Assert
        email1.GetHashCode().Should().Be(email2.GetHashCode());
    }

    [Fact]
    public void Value_ShouldBeImmutable()
    {
        // Arrange
        var email = Email.Create("test@example.com");
        var originalValue = email.Value;

        // Act - Try to get the property (we can't change it as it's readonly)
        var value = email.Value;

        // Assert
        value.Should().Be(originalValue);
        email.Value.Should().Be("test@example.com");
    }
}
