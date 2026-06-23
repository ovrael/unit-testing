using game_damage_project.Models;

namespace game_damage_project.Interfaces;

public interface IDamageable
{
    public double ComputeDamage(Attack attack);
}
