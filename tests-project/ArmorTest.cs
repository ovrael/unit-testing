namespace tests_project;

using FluentAssertions;
using game_damage_project.Enums;
using game_damage_project.Models;

public class ArmorTest
{
    [Fact]
    public void TestDefaultValue()
    {
        Armor armor = new Armor();
        armor.LimitedValue.Should().Be(0);
    }

    [Theory]
    [InlineData(0, 950, 950)]
    [InlineData(-50, 950, 900)]
    [InlineData(0, -520, 0)]
    [InlineData(100, 200, 300)]
    [InlineData(-47, -75, 0)]
    public void ChangeMaxArmorValue_Expected(int baseValue, int newValue, int limitedExpected)
    {
        Armor armor = new Armor(baseValue);
        armor.ChangeValue(newValue);
        armor.LimitedValue.Should().Be(limitedExpected);
    }

    [Theory]
    [InlineData(1500, 2500, 2500)]
    [InlineData(-205, 25, 25)]
    [InlineData(0, 555, 555)]
    public void SetMaxArmorValue_Expected(int baseValue, int newValue, int limitedExpected)
    {
        Armor armor = new Armor(baseValue);
        armor.SetValue(newValue);
        armor.LimitedValue.Should().Be(limitedExpected);
    }
}
