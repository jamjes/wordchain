using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class WordManager : MonoBehaviour
{

    #region Attributes

    KeysPooler pooler;
    List<Key> keys;
    int pointer = 0;

    public delegate void Word(string word);
    public static event Word OnWordAccept;
    public static event Word OnWordComplete;
    public delegate void UXDelegate();
    public static event UXDelegate OnWordRevert;

    #endregion

    #region Methods

    #region MonoBehaviour

    void OnEnable()
    {
        PlayerController.OnKeyPress += Append;
        PlayerController.OnKeyDelete += Remove;

        WinConditionHandler.OnAccept += CycleLetters;
        WinConditionHandler.OnRepeat += CancelScore;
    }

    void OnDisable()
    {
        PlayerController.OnKeyPress -= Append;
        PlayerController.OnKeyDelete -= Remove;

        WinConditionHandler.OnAccept -= CycleLetters;
        WinConditionHandler.OnRepeat -= CancelScore;
    }

    void Start()
    {
        keys = new List<Key>();
        pooler = GetComponent<KeysPooler>();

        char randomLetter = (char)Random.Range(97, 123);
        Append(randomLetter);
    }

    #endregion

    void Append(char letter)
    {
        if (pointer == 5)
        {
            return;
        }

        Key newKey = pooler.RequestAppend();
        newKey.SetCharacter(letter);
        newKey.SetValue(CalculateCharacterValue(letter));
        

        Vector3 targetLocation = new Vector3(-240, 0, 0);
        
        if (keys.Count != 0)
        {
            targetLocation = keys[keys.Count - 1].GetComponent<RectTransform>().localPosition + new Vector3(120, 0, 0);
        }

        newKey.GetComponent<RectTransform>().localPosition = targetLocation;
        keys.Add(newKey);

        pointer++;
        GameManager.Instance.UpdateGuess(letter);

        if (pointer == 5 && OnWordComplete != null)
        {
            OnWordComplete(GameManager.Instance.PlayerGuess);
        }
    }

    void Remove()
    {
        if (pointer == 1)
        {
            return;
        }

        pointer--;

        if (pointer == 4 && OnWordRevert != null)
        {
            OnWordRevert();
        }

        pooler.RequestRemove(keys[keys.Count - 1]);
        keys.RemoveAt(keys.Count - 1);

        GameManager.Instance.RemoveFromGuess();
    }

    void CycleLetters()
    {
        if (OnWordRevert != null)
        {
            OnWordRevert();
        }

        foreach(Key key in keys)
        {
            GameManager.Instance.AddToScore(key.Value);
            key.Lerper.BeginLerp();
        }

        StartCoroutine(AnimationEvent());
    }

    void CancelScore()
    {
        foreach (Key key in keys)
        {
            key.Lerper.BeginLerp();
        }

        StartCoroutine(AnimationEvent());
    }

    IEnumerator AnimationEvent()
    {
        yield return new WaitForSeconds(.3f);
        
        pointer = 1;

        for (int counter = 0; counter < 4; counter++)
        {
            Key currentKey = keys[0];
            currentKey.SetCharacter(' ');
            currentKey.gameObject.SetActive(false);
            keys.RemoveAt(0);
        }
    }

    int CalculateCharacterValue(char letter)
    {
        switch(letter)
        {
            case 'a': return 1;
            case 'e': return 1;
            case 'i': return 1;
            case 'o': return 1;
            case 'u': return 1;
            case 'l': return 1;
            case 'n': return 1;
            case 's': return 1;
            case 't': return 1;
            case 'r': return 1;

            case 'd': return 2;
            case 'g': return 2;

            case 'b': return 3;
            case 'c': return 3;
            case 'm': return 3;
            case 'p': return 3;

            case 'f': return 4;
            case 'h': return 4;
            case 'v': return 4;
            case 'w': return 4;
            case 'y': return 4;
            
            case 'k': return 5;

            case 'x': return 8;
            case 'j': return 8;

            case 'q': return 10;
            case 'z': return 10;
        }

        return 0;
    }

    #endregion

}
