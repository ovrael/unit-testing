namespace game_damage_project.Models;

public class Evasion(int value = 0)
{
    private static readonly int minValue = 0;
    public int LimitedValue { get; private set; } = value;
    private int trueValue = value;

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
        LimitedValue = trueValue <= minValue ? minValue : trueValue;
    }

    public bool ComputeEvade()
    {
        double chance = Math.Min(LimitedValue / 5000.0, 0.95);
        return Random.Shared.NextDouble() <= chance;
    }
}
