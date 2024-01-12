using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timerScript : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    private bool isTiming;

    private void Start()
    {
        ResetTimer();
        StartTimer();
    }

    private void Update()
    {
        if (isTiming)
        {
            float currentTime = Time.time - startTime;
            timerText.text = FormatTime(currentTime);
        }
    }

    public void StartTimer()
    {
        isTiming = true;
        startTime = Time.time;
    }

    public void StopTimer()
    {
        isTiming = false;
    }

    public void ResetTimer()
    {
        isTiming = false;
        timerText.text = "00:00.000";
    }

    private string FormatTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time - (minutes * 60 + seconds)) * 1000);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
