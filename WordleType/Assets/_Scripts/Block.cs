using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    char letter;
    int value;
    [SerializeField] TextMeshProUGUI letterAsUI;

    public delegate void BlockDelegate(Block self);
    public static event BlockDelegate OnBlockUpdate;

    public int GetValue()
    {
        return value;
    }

    public char GetLetter()
    {
        return letter;
    }

    private void Start()
    {
        letterAsUI.text = letter.ToString();
    }

    public void UpdateBlock(char letter, int value)
    {
        this.letter = letter;
        this.value = value;
        letterAsUI.text = this.letter.ToString();

        if (OnBlockUpdate != null)
        {
            OnBlockUpdate(this);
        }
    }
}
