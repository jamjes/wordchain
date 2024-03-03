using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backspace : MonoBehaviour
{
    public delegate void BackspaceDelegate();
    public static event BackspaceDelegate RemoveLastLetter;
    
    public void ButtonPress()
    {
        if (RemoveLastLetter != null)
        {
            RemoveLastLetter();
        }
    }
}
