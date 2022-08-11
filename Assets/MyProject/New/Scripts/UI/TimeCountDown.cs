using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeCountDown : MonoBehaviour
{
    private TMP_Text txtTime;
    public int timeDown;
    private bool takingAway = false;
    private bool timeUp = false;
    private void Awake()
    {
        takingAway = false;
        txtTime = GetComponent<TMP_Text>();
        UpdateTime();
    }
    private void UpdateTime()
    {
        txtTime.text = $"Time: {GetFormatStringTime()}";
    }
    private string GetFormatStringTime()
    {
        int minutes = timeDown / 60;
        int seconds = timeDown - minutes * 60;
        string secondString = seconds < 10 ? "0" + seconds : seconds.ToString();
        return $"{minutes}:{secondString}";
    }
    private void Update()
    {
        if (takingAway == false && timeDown > 0)
        {
            StartCoroutine(TimerTake());
        }
        else if(timeDown <= 0 && timeUp == false)
        {
            TimeUpHandle();
            timeUp = true;
        }
    }

    public virtual void TimeUpHandle()
    {
    }

    private IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeDown--;
        UpdateTime();
        takingAway = false;
    }
}
