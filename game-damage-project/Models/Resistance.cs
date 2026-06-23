using game_damage_project.Enums;

namespace game_damage_project.Models;

public class Resistance(DamageType type, int value = 0)
{
    public static readonly int BaseMaxValue = 75;
    public static readonly int HardMaxValue = 90;

    public DamageType DamageType { get; init; } = type;
    public int LimitedValue { get; private set; } = value;
    public int TrueValue { get; private set; } = value;
    public int LimitedMaxValue { get; private set; } = BaseMaxValue;
    public int TrueMaxValue { get; private set; } = BaseMaxValue;

    public void ChangeValue(int change)
    {
        TrueValue += change;
        ComputeLimitedValues();
    }

    public void SetValue(int newValue)
    {
        TrueValue = newValue;
        ComputeLimitedValues();
    }

    public void ChangeMaxValue(int change)
    {
        TrueMaxValue += change;
        ComputeLimitedValues();
    }

    public void SetMaxValue(int newMaxValue)
    {
        TrueMaxValue = newMaxValue;
        ComputeLimitedValues();
    }

    private void ComputeLimitedValues()
    {
        // Update max value with limits
        if (TrueMaxValue >= HardMaxValue)
            LimitedMaxValue = HardMaxValue;
        else if (TrueMaxValue <= BaseMaxValue)
            LimitedMaxValue = BaseMaxValue;
        else
            LimitedMaxValue = TrueMaxValue;

        // Update resistance value with upper limit
        if (TrueValue >= LimitedMaxValue)
            LimitedValue = LimitedMaxValue;
        else
            LimitedValue = TrueValue;
    }
}
