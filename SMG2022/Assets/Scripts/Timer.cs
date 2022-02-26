using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timeText;
    private bool isPaused;
    private float timeLimit;
    private GameSceneManager mgr;

    private void Awake()
    {
        timeText = GetComponent<Text>();
    }

    public void StartTimer(GameSceneManager mgr, float time)
    {
        this.mgr = mgr;

        if (time <= 0)
        {
            return;
        }

        timeLimit = time;
        StartCoroutine(TimerCo());
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }

    private IEnumerator TimerCo()
    {
        float tmpTime = timeLimit;

        while (tmpTime > 0)
        {
            if (isPaused)
            {
                yield return null;
                continue;
            }

            if (tmpTime > 0)
            {
                tmpTime -= Time.deltaTime;

                timeText.text = GetTimeString(tmpTime);
                yield return null;
            }
        }

        mgr.ReturnResult(false);
    }

    private string GetTimeString(float time)
    {
        float tmpTime = Mathf.Ceil(time);
        int minute = (int) tmpTime / 60;
        int second = (int) tmpTime % 60;

        return $"{minute:00}:{second:00}";
    }
}
