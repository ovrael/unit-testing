namespace game_damage_project.Models;

public class Attack
{
    public IReadOnlyList<DamageInstance> Damages { get; init; } = [];
    public bool IsCritical { get; init; }
    public double CritMultiplier { get; init; }
}
