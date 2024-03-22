using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Key : MonoBehaviour
{

    #region Attributes

    [SerializeField] TextMeshProUGUI characterAsUI, valueAsUI;
    [SerializeField] Image sprite;
    
    public int Value { get; private set; }
    public char Character { get; private set; }

    public Lerper Lerper { get; private set; }
    bool isLerping;

    #endregion

    #region Methods

    #region MonoBehaviour

    void Start()
    {
        Lerper = new Lerper(.3f, GetComponent<RectTransform>());
        isLerping = false;
    }

    void Update()
    {
        if (Lerper.Run)
        {
            Lerper.Tick();
        }
    }

    #endregion

    public void SetCharacter(char character)
    {
        this.Character = character;
        characterAsUI.text = Character.ToString();
    }

    public void SetValue(int value)
    {
        this.Value = value;
        valueAsUI.text = Value.ToString();
    }

    #endregion

}
