using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    public Vector3 StartPosition { private set; get; }
    public Vector3 EndPosition { private set; get; }
    bool lerping;
    float elapsedTime, duration;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void BeginLerp(Vector3 startPosition, Vector3 endPosition, float duration)
    {
        StartPosition = startPosition;
        EndPosition = endPosition;
        this.duration = duration;
        elapsedTime = 0;
        lerping = true;
    }

    void Update()
    {
        if (lerping == true)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;

            if (percentageComplete > 1)
            {
                percentageComplete = 1;
            }

            rectTransform.localPosition = Vector3.Lerp(StartPosition, EndPosition, percentageComplete);

            if (percentageComplete == 1)
            {
                lerping = false;
            }
        }
    }
}
