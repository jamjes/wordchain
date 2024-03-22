using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    #region Attributes

    public static GameManager Instance;
    
    Timer levelTimer; 
    Score levelScore;
    
    [SerializeField] float levelDuration;
    [SerializeField] TextMeshProUGUI timerLabel, scoreLabel;
    
    public string PlayerGuess { private set; get; }
    public bool Run { get; private set; }

    public delegate void ManagerDelegate();
    public static event ManagerDelegate OnInitialise;

    #endregion

    #region Methods

    #region MonoBehaviour
    void OnEnable()
    {
        WinConditionHandler.OnAccept += UpdateTimer;
        WinConditionHandler.OnRepeat += ResetWord;
        Timer.OnTimerEnd += EndGame;
    }

    void OnDisable()
    {
        WinConditionHandler.OnAccept -= UpdateTimer;
        WinConditionHandler.OnRepeat -= ResetWord;
        Timer.OnTimerEnd -= EndGame;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        if (OnInitialise != null)
        {
            OnInitialise();
        }

        Run = false;
        levelScore = new Score(scoreLabel, 0);
        levelTimer = new Timer(timerLabel, levelDuration);
        
        float startDelay = 3;
        StartCoroutine(StartGame(startDelay));
    }

    void Update()
    {
        if (!Run)
        {
            return;
        }

        if (levelTimer != null)
        {
            levelTimer.Tick();
            timerLabel.text = levelTimer.TimeRemaining.ToString("0.0");
        }
    }

    #endregion

    IEnumerator StartGame(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        Run = true;
    }

    void EndGame()
    {
        Run = false;
    }

    public void UpdateTimer()
    {
        levelTimer.AddToTimer(4);
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
        levelScore.Add(value);
    }

    public void SubtractFromScore(int value)
    {
        levelScore.Subtract(value);
    }

    #endregion

}
