using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTimer : MonoBehaviour
{
    public float time;
    TimerUI timerUI;
    public bool timeRunning;

    private void Awake()
    {
        timeRunning = true;
        timerUI = FindObjectOfType<TimerUI>();
    }
    private void Update()
    {
        timerUI.UpdateTime(time);
        if (timeRunning == true)
        {
            time += Time.deltaTime;
        }
        
        
    }
}
