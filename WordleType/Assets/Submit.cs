using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submit : MonoBehaviour
{
    public delegate void SubmitDelegate();
    public static event SubmitDelegate OnSubmit;

    public void ButtonPress()
    {
        if (OnSubmit != null)
        {
            OnSubmit();
        }
    }
}
