using UnityEngine;

public class Lerper
{
    #region Attributes

    float elapsedTime = 0;
    float duration = .3f;
    Vector3 startPosition, endPosition;
    RectTransform rectTransform;
    public bool Run { get; private set; }

    #endregion

    #region Methods

    public Lerper(float duration, RectTransform rectTransform)
    {
        this.duration = duration;
        this.rectTransform = rectTransform;
    }
    
    public void Tick()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / duration;

        if (percentageComplete > 1)
        {
            percentageComplete = 1;
        }

        rectTransform.localPosition =  Vector3.Lerp(startPosition, endPosition, percentageComplete);

        if (percentageComplete == 1)
        {
            Run = false;
        }
    }

    public void BeginLerp()
    {
        elapsedTime = 0;
        startPosition = rectTransform.localPosition;
        endPosition = startPosition - new Vector3(480, 0, 0);
        Run = true;
    }

    #endregion

}
