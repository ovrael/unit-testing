namespace tests_project;

using FluentAssertions;
using game_damage_project.Enums;
using game_damage_project.Models;

public class ResistanceTest
{
    private static readonly int baseMaxValue = 75; // Minimal value that Resistance's maxValue can be
    private static readonly int hardMaxValue = 90; // Maximum value that Resistance's maxValue can be

    private readonly Resistance fireResistance;

    public ResistanceTest()
    {
        fireResistance = new Resistance(DamageType.Fire);
    }

    [Fact]
    public void TestDefaultValue()
    {
        fireResistance.Value.Should().Be(0);
        fireResistance.DamageType.Should().Be(DamageType.Fire);
    }

    [Theory]
    [InlineData(50, 20, 70)]
    [InlineData(0, 90, 75)]
    [InlineData(0, -20, -20)]
    [InlineData(-10, -30, -40)]
    [InlineData(-20, 100, 75)]
    public void ChangeResistanceValue_Expected(int baseValue, int change, int expected)
    {
        Resistance iceResistance = new Resistance(DamageType.Ice, baseValue);
        iceResistance.ChangeValue(change);
        iceResistance.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 75)]
    [InlineData(-5, 75)]
    [InlineData(5, 80)]
    [InlineData(15, 90)]
    [InlineData(-20, 75)]
    [InlineData(25, 90)]
    public void ChangeMaxResistanceValue_Expected(int change, int expected)
    {
        fireResistance.ChangeMaxValue(change);
        fireResistance.MaxValue.Should().Be(expected);
    }

    [Theory]
    [InlineData(90, 75)]
    [InlineData(-20, -20)]
    [InlineData(100, 75)]
    [InlineData(47, 47)]
    public void SetResistanceValue_Expected(int newValue, int expected)
    {
        fireResistance.SetValue(newValue);
        fireResistance.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData(95, 90)]
    [InlineData(-20, 75)]
    [InlineData(85, 85)]
    [InlineData(47, 75)]
    public void SetMaxResistanceValue_Expected(int newValue, int expected)
    {
        fireResistance.SetMaxValue(newValue);
        fireResistance.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData(50, 20, 10, 70)]
    [InlineData(0, 100, -5, 75)]
    [InlineData(0, -100, 20, -100)]
    [InlineData(20, 100, 20, 90)]
    [InlineData(20, 100, 5, 80)]
    [InlineData(0, 80, 5, 80)]
    public void ChangeResistanceValue_WithChangingMax_ValueFirst_Expected(
        int baseValue,
        int change,
        int changeMax,
        int expected
    )
    {
        Resistance iceResistance = new Resistance(DamageType.Ice, baseValue);
        iceResistance.ChangeValue(change);
        iceResistance.ChangeMaxValue(changeMax);
        iceResistance.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData(50, 20, 10, 70)]
    [InlineData(0, 100, -5, 75)]
    [InlineData(0, -100, 20, -100)]
    [InlineData(20, 100, 20, 90)]
    [InlineData(20, 100, 5, 80)]
    [InlineData(0, 80, 5, 80)]
    public void ChangeResistanceValue_WithChangingMax_MaxFirst_Expected(
        int baseValue,
        int change,
        int changeMax,
        int expected
    )
    {
        Resistance iceResistance = new Resistance(DamageType.Ice, baseValue);
        iceResistance.ChangeMaxValue(changeMax);
        iceResistance.ChangeValue(change);
        iceResistance.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData(50, 20, 20)]
    [InlineData(0, 90, 75)]
    [InlineData(0, -20, -20)]
    [InlineData(-10, -30, -30)]
    [InlineData(-20, 100, 75)]
    public void SetResistanceValue_WithoutChangingMax_Expected(
        int baseValue,
        int newValue,
        int expected
    )
    {
        Resistance iceResistance = new Resistance(DamageType.Ice, baseValue);
        iceResistance.SetValue(newValue);
        iceResistance.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData(50, 20, 10, 70)]
    [InlineData(0, 100, -5, 75)]
    [InlineData(0, -100, 20, -100)]
    [InlineData(20, 100, 20, 90)]
    [InlineData(20, 100, 5, 80)]
    [InlineData(0, 80, 5, 80)]
    public void SetResistanceValue_WithChangingMax_ValueFirst_Expected(
        int baseValue,
        int change,
        int changeMax,
        int expected
    )
    {
        Resistance iceResistance = new Resistance(DamageType.Ice, baseValue);
        iceResistance.ChangeValue(change);
        iceResistance.ChangeMaxValue(changeMax);
        iceResistance.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData(50, 20, 10, 70)]
    [InlineData(0, 100, -5, 75)]
    [InlineData(0, -100, 20, -100)]
    [InlineData(20, 100, 20, 90)]
    [InlineData(20, 100, 5, 80)]
    [InlineData(0, 80, 5, 80)]
    public void SetResistanceValue_WithChangingMax_MaxFirst_Expected(
        int baseValue,
        int change,
        int changeMax,
        int expected
    )
    {
        Resistance iceResistance = new Resistance(DamageType.Ice, baseValue);
        iceResistance.ChangeMaxValue(changeMax);
        iceResistance.ChangeValue(change);
        iceResistance.Value.Should().Be(expected);
    }
}
