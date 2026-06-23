namespace game_damage_project.Interfaces;

public interface IHasHealth
{
    double MaxHealth { get; }
    double CurrentHealth { get; }
}
