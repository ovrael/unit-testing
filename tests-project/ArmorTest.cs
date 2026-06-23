namespace tests_project;

using FluentAssertions;
using game_damage_project.Enums;
using game_damage_project.Models;

public class ArmorTest
{
    private readonly Armor armor;

    public ArmorTest()
    {
        armor = new Armor();
    }

    [Fact]
    public void TestDefaultValue()
    {
        armor.Value.Should().Be(0);
    }
}
