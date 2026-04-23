using FluentAssertions;
using RegisterApp.Domain.UserManagement.ValueObjects;

namespace RegisterApp.Domain.Tests.UserManagement.ValueObjects;

public class UserRoleTests
{
    [Theory]
    [InlineData("Admin")]
    [InlineData("User")]
    public void Create_WithValidRole_ShouldSucceed(string validRole)
    {
        // Act
        var role = UserRole.Create(validRole);

        // Assert
        role.Should().NotBeNull();
        role.Value.Should().Be(validRole);
    }

    [Theory]
    [InlineData("admin")]
    [InlineData("ADMIN")]
    [InlineData("AdMiN")]
    public void Create_WithAdminInDifferentCase_ShouldSucceed(string roleValue)
    {
        // Act
        var role = UserRole.Create(roleValue);

        // Assert
        role.Should().NotBeNull();
        role.Value.Should().Be(roleValue);
    }

    [Theory]
    [InlineData("user")]
    [InlineData("USER")]
    [InlineData("UsEr")]
    public void Create_WithUserInDifferentCase_ShouldSucceed(string roleValue)
    {
        // Act
        var role = UserRole.Create(roleValue);

        // Assert
        role.Should().NotBeNull();
        role.Value.Should().Be(roleValue);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_WithEmptyRole_ShouldThrowArgumentException(string? emptyRole)
    {
        // Act
        Action act = () => UserRole.Create(emptyRole!);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Role cannot be empty*");
    }

    [Theory]
    [InlineData("InvalidRole")]
    [InlineData("SuperAdmin")]
    [InlineData("Guest")]
    [InlineData("Moderator")]
    public void Create_WithInvalidRole_ShouldThrowArgumentException(string invalidRole)
    {
        // Act
        Action act = () => UserRole.Create(invalidRole);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Invalid role*");
    }

    [Fact]
    public void AdminConstant_ShouldBeValid()
    {
        // Act
        var role = UserRole.Admin;

        // Assert
        role.Should().NotBeNull();
        role.Value.Should().Be("Admin");
    }

    [Fact]
    public void UserConstant_ShouldBeValid()
    {
        // Act
        var role = UserRole.User;

        // Assert
        role.Should().NotBeNull();
        role.Value.Should().Be("User");
    }

    [Fact]
    public void IsAdmin_WithAdminRole_ShouldReturnTrue()
    {
        // Arrange
        var role = UserRole.Create("Admin");

        // Act
        var result = role.IsAdmin();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsAdmin_WithUserRole_ShouldReturnFalse()
    {
        // Arrange
        var role = UserRole.Create("User");

        // Act
        var result = role.IsAdmin();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsUser_WithUserRole_ShouldReturnTrue()
    {
        // Arrange
        var role = UserRole.Create("User");

        // Act
        var result = role.IsUser();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsUser_WithAdminRole_ShouldReturnFalse()
    {
        // Arrange
        var role = UserRole.Create("Admin");

        // Act
        var result = role.IsUser();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WithSameRole_ShouldReturnTrue()
    {
        // Arrange
        var role1 = UserRole.Create("Admin");
        var role2 = UserRole.Create("Admin");

        // Act & Assert
        role1.Should().Be(role2);
        (role1 == role2).Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentCase_ShouldReturnTrue()
    {
        // Arrange
        var role1 = UserRole.Create("Admin");
        var role2 = UserRole.Create("admin");

        // Act & Assert
        role1.Should().Be(role2);
        (role1 == role2).Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentRole_ShouldReturnFalse()
    {
        // Arrange
        var role1 = UserRole.Create("Admin");
        var role2 = UserRole.Create("User");

        // Act & Assert
        role1.Should().NotBe(role2);
        (role1 != role2).Should().BeTrue();
    }

    [Fact]
    public void ToString_ShouldReturnRoleValue()
    {
        // Arrange
        var role = UserRole.Create("Admin");

        // Act
        var result = role.ToString();

        // Assert
        result.Should().Be("Admin");
    }

    [Fact]
    public void GetHashCode_WithSameRole_ShouldReturnSameHashCode()
    {
        // Arrange
        var role1 = UserRole.Create("Admin");
        var role2 = UserRole.Create("admin");

        // Act & Assert
        role1.GetHashCode().Should().Be(role2.GetHashCode());
    }

    [Fact]
    public void Value_ShouldBeImmutable()
    {
        // Arrange
        var role = UserRole.Create("Admin");
        var originalValue = role.Value;

        // Act
        var value = role.Value;

        // Assert
        value.Should().Be(originalValue);
        role.Value.Should().Be("Admin");
    }

    [Fact]
    public void AdminConstant_ShouldBeSameInstance()
    {
        // Act
        var admin1 = UserRole.Admin;
        var admin2 = UserRole.Admin;

        // Assert
        admin1.Should().BeSameAs(admin2);
    }

    [Fact]
    public void UserConstant_ShouldBeSameInstance()
    {
        // Act
        var user1 = UserRole.User;
        var user2 = UserRole.User;

        // Assert
        user1.Should().BeSameAs(user2);
    }
}
