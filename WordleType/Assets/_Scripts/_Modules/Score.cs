using TMPro;

public struct Score
{
    public int Value { get; private set; }
    TextMeshProUGUI label;

    public Score(TextMeshProUGUI label, int startingValue)
    {
        this.label = label;
        this.Value = startingValue;
        label.text = Value.ToString("000");
    }

    public void Add(int amount)
    {
        Value += amount;
        label.text = Value.ToString("000");
    }

    public void Subtract(int amount)
    {
        Value -= amount;
        label.text = Value.ToString("000");
    }
}
