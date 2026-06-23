namespace game_damage_project.Models;

public class Armor(int value = 0)
{
    private static readonly int minValue = 0;
    public int Value { get; private set; } = value;
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
        Value = trueValue <= minValue ? minValue : trueValue;
    }
}
