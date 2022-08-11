using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCountDownEndGame : TimeCountDown
{
    public override void TimeUpHandle()
    {
        EventManager.EndGame?.Invoke(false);
    }
}
