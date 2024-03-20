using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI timerLabel;
    public float Timer { private set; get; }
    public int Score { private set; get; }
    public string PlayerGuess { private set; get; }

    private void OnEnable()
    {
        WinConditionHandler.OnAccept += UpdateTimer;
        WinConditionHandler.OnRepeat += ResetWord;
    }

    private void OnDisable()
    {
        WinConditionHandler.OnAccept -= UpdateTimer;
        WinConditionHandler.OnRepeat -= ResetWord;
    }

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

        Timer = 10;
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
        timerLabel.text = Timer.ToString("00");
    }

    public void UpdateTimer()
    {
        Timer += 5;
        ResetWord();
    }

    public void ResetWord()
    {
        PlayerGuess = PlayerGuess.Remove(0, 4);
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
