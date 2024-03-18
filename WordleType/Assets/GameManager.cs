using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreLabel;
    public int Score { private set; get; }
    public string PlayerGuess { private set; get; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateGuess(char letter)
    {
        PlayerGuess += letter;
    }

    public void RemoveFromGuess()
    {
        PlayerGuess = PlayerGuess.Remove(PlayerGuess.Length - 1, 1);
    }

    public void AddToScore(int value)
    {
        Score += value;
        scoreLabel.text = Score.ToString();
    }

    public void SubtractFromScore(int value)
    {
        Score -= value;
        scoreLabel.text = Score.ToString();
    }
}
