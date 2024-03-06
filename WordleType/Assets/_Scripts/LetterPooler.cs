using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPooler : MonoBehaviour
{
    [SerializeField] int amountToPool;
    [SerializeField] GameObject letterPrefab;

    void Start()
    {
        for(int count = 0; count < amountToPool; count++)
        {
            GameObject letter = Instantiate(letterPrefab);
            
        }
    }
}
