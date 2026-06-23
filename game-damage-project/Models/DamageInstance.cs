using game_damage_project.Enums;

namespace game_damage_project.Models;

public record DamageInstance
{
    public DamageType DamageType { get; set; }
    public double Amount { get; set; }
}
