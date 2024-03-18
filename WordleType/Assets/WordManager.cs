using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    KeysPooler pooler;
    List<Key> keys;
    int pointer = 0;

    void OnEnable()
    {
        PlayerController.OnKeyPress += Append;
        PlayerController.OnKeyDelete += Remove;
        PlayerController.OnSuccess += CheckWinCondition;
        PlayerController.OnError += CheckWinCondition;
        PlayerController.OnRepeat += CheckWinCondition;
    }

    void OnDisable()
    {
        PlayerController.OnKeyPress -= Append;
        PlayerController.OnKeyDelete -= Remove;
        PlayerController.OnSuccess -= CheckWinCondition;
        PlayerController.OnError -= CheckWinCondition;
        PlayerController.OnRepeat -= CheckWinCondition;
    }

    void Start()
    {
        keys = new List<Key>();
        pooler = GetComponent<KeysPooler>();

        char randomLetter = (char)Random.Range(96, 123);
        Append(randomLetter);
    }

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
    }

    void Remove()
    {
        if (pointer == 1)
        {
            return;
        }

        pointer--;

        pooler.RequestRemove(keys[keys.Count - 1]);
        keys.RemoveAt(keys.Count - 1);

        GameManager.Instance.RemoveFromGuess();
    }

    void CheckWinCondition()
    {
        if (pointer != 5)
        {
            return;
        }
        
        int condition = 0;

        Vector3 startPosition;
        Vector3 endPosition;

        #region LerpToEndPosition

        for (int counter = 0; counter < keys.Count; counter++)
        {
            GameManager.Instance.AddToScore(keys[counter].Value);

            startPosition = keys[counter].GetComponent<RectTransform>().localPosition;
            endPosition = startPosition - new Vector3(480, 0, 0);
            keys[counter].GetComponent<UIAnimator>().BeginLerp(startPosition, endPosition, .3f);
        }

        #endregion

        StartCoroutine(AnimationEvent());
    }

    IEnumerator AnimationEvent()
    {
        yield return new WaitForSeconds(.3f);
        
        pointer = 1;

        #region CycleKeys
        for (int counter = 0; counter < 4; counter++)
        {
            Key currentKey = keys[0];
            currentKey.SetCharacter(' ');
            currentKey.gameObject.SetActive(false);
            keys.RemoveAt(0);
        }
        #endregion
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
}
