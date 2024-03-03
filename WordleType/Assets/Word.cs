using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;

public class Word : MonoBehaviour
{
    public string word;
    public TextMeshProUGUI[] wordDisplay;
    public int score;

    private Key currentKey;
    
    private void OnEnable()
    {
        Key.AddLetter += AppendToWord;
        Backspace.RemoveLastLetter += RemoveFromWord;
        Submit.OnSubmit += CheckWord;
    }

    private void OnDisable()
    {
        Key.AddLetter -= AppendToWord;
        Backspace.RemoveLastLetter -= RemoveFromWord;
        Submit.OnSubmit -= CheckWord;
    }

    private void AppendToWord(Key target)
    {
        currentKey = target;
        
        if (word.Length < 5)
        {
            word += target.Value.text;
            wordDisplay[word.Length - 1].text = target.Value.text;
            score += target.value;
        }
        
    }

    private void RemoveFromWord()
    {
        if (word.Length > 0)
        {
            word = word.Remove(word.Length - 1, 1);
            wordDisplay[word.Length].text = "";
            score -= currentKey.value;
        }
    }

    private void CheckWord()
    {
        if (word.Length == 5)
        {
            Debug.Log($"Player has submitted {word}.");
            word = "";

            foreach(TextMeshProUGUI target in wordDisplay)
            {
                target.text = "";
            }
        }

        
    }
}
