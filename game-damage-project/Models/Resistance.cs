using game_damage_project.Enums;

namespace game_damage_project.Models;

public class Resistance(DamageType type, int value = 0)
{
    public DamageType DamageType { get; init; } = type;
    public int Value { get; private set; } = value;
    private int trueValue = value;
    public int MaxValue { get; private set; } = 75;
    private static readonly int baseMaxValue = 75;
    private static readonly int hardMaxValue = 90;

    public void ChangeMaxValue(int change)
    {
        MaxValue += change;
        ComputeValue();
    }

    public void SetMaxValue(int newMaxValue)
    {
        MaxValue = newMaxValue;
        ComputeValue();
    }

    public void ChangeValue(int change)
    {
        trueValue += change;
        ComputeValue();
    }

    public void SetValue(int newValue)
    {
        trueValue = newValue;
        ComputeValue();
    }

    private void ComputeValue()
    {
        // Check if max is between base and hard max
        int max =
            MaxValue >= hardMaxValue ? hardMaxValue
            : MaxValue <= baseMaxValue ? baseMaxValue
            : MaxValue;

        Value = trueValue >= max ? max : trueValue;
    }
}
