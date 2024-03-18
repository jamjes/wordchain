using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI characterAsUI, valueAsUI;
    public int Value { get; private set; }
    public char Character { get; private set; }

    public void SetCharacter(char character)
    {
        this.Character = character;
        characterAsUI.text = Character.ToString();
    }

    public void SetValue(int value)
    {
        this.Value = value;
        valueAsUI.text = Value.ToString();
    }
}
