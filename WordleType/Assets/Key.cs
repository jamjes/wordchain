using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] char letter;
    [SerializeField] KeyCode letterAsKeyCode;
    [SerializeField] TextMeshProUGUI letterAsUI, popUpLetterAsUI;
    [SerializeField] int value;
    [SerializeField] TextMeshProUGUI valueAsUI;
    [SerializeField] Image popUp, background;
    [SerializeField] Color mainTextColor, highlightTextColor, mainBackgroundColor, highlightBackgroundColor;


    public delegate void KeyDelegate(Key target);
    public static event KeyDelegate AddLetter;

    private void Start()
    {
        letterAsUI.text = letter.ToString();
        popUpLetterAsUI.text = letter.ToString();
        valueAsUI.text = value.ToString();
        popUp.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(letterAsKeyCode))
        {
            KeyEnter();
        }
        
        if (Input.GetKeyUp(letterAsKeyCode))
        {
            KeyExit();
        }
    }

    public void KeyEnter()
    {
        background.color = highlightBackgroundColor;
        letterAsUI.color = highlightTextColor;
        popUp.gameObject.SetActive(true);
    }

    public void KeyExit()
    {
        background.color = mainBackgroundColor;
        letterAsUI.color = mainTextColor;
        popUp.gameObject.SetActive(false);
    }

}
