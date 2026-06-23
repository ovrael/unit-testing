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
        fireResistance.LimitedValue.Should().Be(0);
        fireResistance.DamageType.Should().Be(DamageType.Fire);
    }

    [Theory]
    [InlineData(50, 20, 70, 70)]
    [InlineData(0, 90, 90, 75)]
    [InlineData(0, -20, -20, -20)]
    [InlineData(-10, -30, -40, -40)]
    [InlineData(-20, 100, 80, 75)]
    public void ChangeResistanceValue_Expected(
        int baseValue,
        int change,
        int trueExpected,
        int limitedExpected
    )
    {
        Resistance iceResistance = new Resistance(DamageType.Ice, baseValue);
        iceResistance.ChangeValue(change);
        iceResistance.TrueValue.Should().Be(trueExpected);
        iceResistance.LimitedValue.Should().Be(limitedExpected);
    }

    [Theory]
    [InlineData(0, 75, 75)]
    [InlineData(-5, 70, 75)]
    [InlineData(5, 80, 80)]
    [InlineData(15, 90, 90)]
    [InlineData(-20, 55, 75)]
    [InlineData(25, 100, 90)]
    public void ChangeMaxResistanceValue_Expected(int change, int trueExpected, int limitedExpected)
    {
        fireResistance.ChangeMaxValue(change);
        fireResistance.TrueMaxValue.Should().Be(trueExpected);
        fireResistance.LimitedMaxValue.Should().Be(limitedExpected);
    }

    [Theory]
    [InlineData(90, 75)]
    [InlineData(-20, -20)]
    [InlineData(100, 75)]
    [InlineData(47, 47)]
    public void SetResistanceValue_Expected(int newValue, int limitedExpected)
    {
        fireResistance.SetValue(newValue);
        fireResistance.TrueValue.Should().Be(newValue);
        fireResistance.LimitedValue.Should().Be(limitedExpected);
    }

    [Theory]
    [InlineData(95, 90)]
    [InlineData(-20, 75)]
    [InlineData(85, 85)]
    [InlineData(47, 75)]
    public void SetMaxResistanceValue_Expected(int newValue, int limitedExpected)
    {
        fireResistance.SetMaxValue(newValue);
        fireResistance.TrueMaxValue.Should().Be(newValue);
        fireResistance.LimitedMaxValue.Should().Be(limitedExpected);
    }

    [Theory]
    [InlineData(50, 20, 10, 70, 70)]
    [InlineData(0, 100, -5, 100, 75)]
    [InlineData(0, -100, 20, -100, -100)]
    [InlineData(20, 100, 20, 120, 90)]
    [InlineData(20, 100, 5, 120, 80)]
    [InlineData(0, 80, 5, 80, 80)]
    [InlineData(15, 90, 10, 105, 85)]
    [InlineData(15, -60, 5, -45, -45)]
    public void ChangeResistanceValue_WithChangingMax_ValueFirst_Expected(
        int baseValue,
        int change,
        int changeMax,
        int trueExpected,
        int limitedExpected
    )
    {
        Resistance iceResistance = new Resistance(DamageType.Ice, baseValue);
        iceResistance.ChangeValue(change);
        iceResistance.ChangeMaxValue(changeMax);
        iceResistance.TrueValue.Should().Be(trueExpected);
        iceResistance.LimitedValue.Should().Be(limitedExpected);
    }

    [Theory]
    [InlineData(50, 20, 10, 70, 70)]
    [InlineData(0, 100, -5, 100, 75)]
    [InlineData(0, -100, 20, -100, -100)]
    [InlineData(20, 100, 20, 120, 90)]
    [InlineData(20, 100, 5, 120, 80)]
    [InlineData(0, 80, 5, 80, 80)]
    [InlineData(15, 90, 10, 105, 85)]
    [InlineData(15, -60, 5, -45, -45)]
    public void ChangeResistanceValue_WithChangingMax_MaxFirst_Expected(
        int baseValue,
        int change,
        int changeMax,
        int trueExpected,
        int limitedExpected
    )
    {
        Resistance iceResistance = new Resistance(DamageType.Ice, baseValue);
        iceResistance.ChangeMaxValue(changeMax);
        iceResistance.ChangeValue(change);
        iceResistance.TrueValue.Should().Be(trueExpected);
        iceResistance.LimitedValue.Should().Be(limitedExpected);
    }
}
