using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Key : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI characterAsUI, valueAsUI;
    [SerializeField] Image sprite;
    Color transitionColor, startColor;
    float elapsedTime, duration = .1f;
    bool colorLerping;
    public int Value { get; private set; }
    public char Character { get; private set; }

    void OnEnable()
    {
        WinConditionHandler.OnHintUpdate += SetColor;
        WordManager.OnWordRevert += ResetColor;
    }

    private void OnDisable()
    {
        WinConditionHandler.OnHintUpdate -= SetColor;
        WordManager.OnWordRevert -= ResetColor;
    }

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

    void SetColor(Color newColor)
    {
        if (colorLerping == true)
        {
            return;
        }

        if (sprite.color == newColor)
        {
            return;
        }

        startColor = sprite.color;
        transitionColor = newColor;
        colorLerping = true;
    }

    void ResetColor()
    {
        if (colorLerping == true)
        {
            return;
        }

        if (sprite.color == Color.white)
        {
            return;
        }

        startColor = sprite.color;
        transitionColor = Color.white;
        colorLerping = true;
        Debug.Log("resetting");
    }

    private void Update()
    {
        if (colorLerping)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;

            if (percentageComplete > 1)
            {
                percentageComplete = 1;
            }

            sprite.color = Color.Lerp(startColor, transitionColor, percentageComplete);

            if (percentageComplete == 1)
            {
                elapsedTime = 0;
                colorLerping = false;
            }
        }
    }
}
