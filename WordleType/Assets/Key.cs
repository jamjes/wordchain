using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public TextMeshProUGUI Value { private set; get; }
    [SerializeField] Image popUp;
    public int value;
    bool state = false;

    public delegate void KeyDelegate(Key target);
    public static event KeyDelegate AddLetter;

    private void Start()
    {
        popUp.gameObject.SetActive(state);
        Value = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void PopUp()
    {
        state = !state;

        if (state == true)
        {
            popUp.gameObject.SetActive(true);
            Value.color = Color.grey;
        }
        else
        {
            popUp.gameObject.SetActive(false);
            Value.color = Color.black;
        }
    }

    public void AppendLetter()
    {
        if (AddLetter != null)
        {
            AddLetter(this);
        }
    }
}
