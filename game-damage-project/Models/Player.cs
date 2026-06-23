using game_damage_project.Enums;
using game_damage_project.Interfaces;

namespace game_damage_project.Models;

public class Player : IHasHealth, IDamageable
{
    public double MaxHealth { get; private set; }
    public double CurrentHealth { get; private set; }
    public string GetHealthStatus => $"{CurrentHealth} / {MaxHealth}";

    private readonly List<Resistance> resistances =
    [
        new Resistance(DamageType.Fire),
        new Resistance(DamageType.Ice),
        new Resistance(DamageType.Lightning),
    ];

    public double ComputeDamage(Attack attack)
    {
        throw new NotImplementedException();
    }
}
