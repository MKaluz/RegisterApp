using FluentAssertions;
using RegisterApp.Domain.UserManagement.ValueObjects;

namespace RegisterApp.Domain.Tests.UserManagement.ValueObjects;

public class FullNameTests
{
    [Theory]
    [InlineData("John", "Doe")]
    [InlineData("Jane", "Smith")]
    [InlineData("Alice", "Johnson")]
    public void Create_WithValidNames_ShouldSucceed(string firstName, string lastName)
    {
        // Act
        var fullName = FullName.Create(firstName, lastName);

        // Assert
        fullName.Should().NotBeNull();
        fullName.FirstName.Should().Be(firstName);
        fullName.LastName.Should().Be(lastName);
    }

    [Theory]
    [InlineData("  John  ", "  Doe  ", "John", "Doe")]
    [InlineData(" Jane ", " Smith ", "Jane", "Smith")]
    public void Create_WithWhitespace_ShouldTrimNames(string firstName, string lastName, string expectedFirst, string expectedLast)
    {
        // Act
        var fullName = FullName.Create(firstName, lastName);

        // Assert
        fullName.FirstName.Should().Be(expectedFirst);
        fullName.LastName.Should().Be(expectedLast);
    }

    [Theory]
    [InlineData("", "Doe")]
    [InlineData(" ", "Doe")]
    [InlineData(null, "Doe")]
    public void Create_WithEmptyFirstName_ShouldThrowArgumentException(string? emptyFirstName, string lastName)
    {
        // Act
        Action act = () => FullName.Create(emptyFirstName!, lastName);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*First name cannot be empty*");
    }

    [Theory]
    [InlineData("John", "")]
    [InlineData("John", " ")]
    [InlineData("John", null)]
    public void Create_WithEmptyLastName_ShouldThrowArgumentException(string firstName, string? emptyLastName)
    {
        // Act
        Action act = () => FullName.Create(firstName, emptyLastName!);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Last name cannot be empty*");
    }

    [Fact]
    public void DisplayName_ShouldReturnFullName()
    {
        // Arrange
        var fullName = FullName.Create("John", "Doe");

        // Act
        var displayName = fullName.DisplayName;

        // Assert
        displayName.Should().Be("John Doe");
    }

    [Fact]
    public void ToString_ShouldReturnDisplayName()
    {
        // Arrange
        var fullName = FullName.Create("John", "Doe");

        // Act
        var result = fullName.ToString();

        // Assert
        result.Should().Be("John Doe");
    }

    [Fact]
    public void Equals_WithSameName_ShouldReturnTrue()
    {
        // Arrange
        var fullName1 = FullName.Create("John", "Doe");
        var fullName2 = FullName.Create("John", "Doe");

        // Act & Assert
        fullName1.Should().Be(fullName2);
        (fullName1 == fullName2).Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentFirstName_ShouldReturnFalse()
    {
        // Arrange
        var fullName1 = FullName.Create("John", "Doe");
        var fullName2 = FullName.Create("Jane", "Doe");

        // Act & Assert
        fullName1.Should().NotBe(fullName2);
        (fullName1 != fullName2).Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentLastName_ShouldReturnFalse()
    {
        // Arrange
        var fullName1 = FullName.Create("John", "Doe");
        var fullName2 = FullName.Create("John", "Smith");

        // Act & Assert
        fullName1.Should().NotBe(fullName2);
        (fullName1 != fullName2).Should().BeTrue();
    }

    [Fact]
    public void GetHashCode_WithSameName_ShouldReturnSameHashCode()
    {
        // Arrange
        var fullName1 = FullName.Create("John", "Doe");
        var fullName2 = FullName.Create("John", "Doe");

        // Act & Assert
        fullName1.GetHashCode().Should().Be(fullName2.GetHashCode());
    }

    [Fact]
    public void FirstNameAndLastName_ShouldBeImmutable()
    {
        // Arrange
        var fullName = FullName.Create("John", "Doe");
        var originalFirstName = fullName.FirstName;
        var originalLastName = fullName.LastName;

        // Act
        var firstName = fullName.FirstName;
        var lastName = fullName.LastName;

        // Assert
        firstName.Should().Be(originalFirstName);
        lastName.Should().Be(originalLastName);
        fullName.FirstName.Should().Be("John");
        fullName.LastName.Should().Be("Doe");
    }

    [Theory]
    [InlineData("Jean-Pierre", "O'Connor")]
    [InlineData("María", "González")]
    [InlineData("Søren", "Müller")]
    public void Create_WithInternationalCharacters_ShouldSucceed(string firstName, string lastName)
    {
        // Act
        var fullName = FullName.Create(firstName, lastName);

        // Assert
        fullName.Should().NotBeNull();
        fullName.FirstName.Should().Be(firstName);
        fullName.LastName.Should().Be(lastName);
    }

    [Fact]
    public void Equals_WithNull_ShouldReturnFalse()
    {
        // Arrange
        var fullName = FullName.Create("John", "Doe");

        // Act & Assert
        fullName.Equals(null).Should().BeFalse();
        (fullName == null).Should().BeFalse();
        (fullName != null).Should().BeTrue();
    }
}
