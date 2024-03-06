using UnityEngine;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI outputText, outputScore, outputGlobalScore, debugText;
    public static LevelManager Instance;
    string playerGuess = "";
    int score;
    int globalScore;
    //[SerializeField] Color acceptColor, declineColor, duplicateColor;
    PlayerResponseTracker tracker;
    public bool Run { private set; get; }

    private void OnEnable()
    {
        Timer.OnTimerEnd += EndGame;
    }

    private void OnDisable()
    {
        Timer.OnTimerEnd -= EndGame;
    }

    void EndGame()
    {
        Run = false;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        int randomInt = Random.Range(97, 122);
        Enqueue((char)randomInt);
        outputText.text = playerGuess;
        tracker = new PlayerResponseTracker();
        Run = true;
    }

    public void Enqueue(char letter)
    {
        if (playerGuess.Length > 4)
        {
            return;
        }

        playerGuess += letter.ToString();
        outputText.text = playerGuess;
        score += GetLetterAsValue(letter);
        outputScore.text = score.ToString();
    }

    public void Dequeue()
    {
        if (playerGuess.Length < 2)
        {
            return;
        }

        score -= GetLetterAsValue(playerGuess[playerGuess.Length - 1]);
        playerGuess = playerGuess.Remove(playerGuess.Length - 1, 1);
        outputText.text = playerGuess;
        outputScore.text = score.ToString();
    }

    public void Submit()
    {
        if (playerGuess.Length != 5)
        {
            return;
        }

        if (tracker.IsRepeat(playerGuess))
        {
            StartCoroutine(DisplayText("String Exists"));
            score = 0;
        }
        else if (tracker.IsRealWord(playerGuess))
        {
            StartCoroutine(DisplayText("Perfect!"));
        }
        else
        {
            StartCoroutine(DisplayText("Word Does Not Exist. Try Again"));
            return;
        }

        globalScore += score;
        outputGlobalScore.text = globalScore.ToString();

        tracker.AppendResponse(playerGuess);

        playerGuess = playerGuess.Remove(0, 4);
        outputText.text = playerGuess;

        score = GetLetterAsValue(playerGuess[0]);
        outputScore.text = score.ToString();

    }

    IEnumerator DisplayText(string text)
    {
        debugText.text = text;
        yield return new WaitForSeconds(1);
        debugText.text = "";
    }

    private int GetLetterAsValue(char letter)
    {
        int currentValue = 0;
        
        switch (letter)
        {
            case 'b':
                currentValue = 3;
                break;
            case 'c':
                currentValue = 3;
                break;
            case 'd':
                currentValue = 2;
                break;
            case 'f':
                currentValue = 4;
                break;
            case 'g':
                currentValue = 2;
                break;
            case 'h':
                currentValue = 4;
                break;
            case 'j':
                currentValue = 8;
                break;
            case 'k':
                currentValue = 5;
                break;
            case 'm':
                currentValue = 3;
                break;
            case 'p':
                currentValue = 3;
                break;
            case 'q':
                currentValue = 10;
                break;
            case 'v':
                currentValue = 4;
                break;
            case 'w':
                currentValue = 4;
                break;
            case 'x':
                currentValue = 8;
                break;
            case 'y':
                currentValue = 4;
                break;
            case 'z':
                currentValue = 10;
                break;
            default:
                currentValue = 1;
                break;
        }

        return currentValue;
    }
}
