using UnityEngine;
using TMPro;

public class Timer
{
    #region Attributes

    public float TimeRemaining { get; private set; }

    public delegate void TimerDelegate();
    public static event TimerDelegate OnTimerEnd;

    TextMeshProUGUI label;

    #endregion

    #region Methods

    public Timer(TextMeshProUGUI uiLabel, float duration)
    {
        TimeRemaining = duration;
        label = uiLabel;
        label.text = TimeRemaining.ToString("0.0");
    }

    public void Tick()
    {
        if (TimeRemaining - Time.deltaTime > 0)
        {
            TimeRemaining -= Time.deltaTime;
            label.text = TimeRemaining.ToString("0.0");
            return;
        }
        
        TimeRemaining = 0;
        label.text = TimeRemaining.ToString("0.0");

        if (OnTimerEnd != null)
        {
            OnTimerEnd();
        }
    }

    public void AddToTimer(float value)
    {
        TimeRemaining += value;
        label.text = TimeRemaining.ToString("0.0");
    }

    #endregion

}
