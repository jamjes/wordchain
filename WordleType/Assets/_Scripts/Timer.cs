using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]float duration;
    [SerializeField] TextMeshProUGUI label;
    public delegate void TimerDelegate();
    public static event TimerDelegate OnTimerEnd;

    /*public Timer(float duration)
    {
        this.duration = duration;
        label.text = duration.ToString();
    }

    public IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(duration);
        if (OnTimerEnd != null)
        {
            OnTimerEnd();
        }
    }*/

    private void Start()
    {
        label.text = duration.ToString();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        duration--;
        label.text = duration.ToString();
        if (duration == 0)
        {
            if (OnTimerEnd != null)
            {
                OnTimerEnd();
            }
        }
        else
        {
            StartCoroutine(Countdown());
        }
    }


}
