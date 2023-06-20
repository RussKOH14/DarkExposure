using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerUI : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTime(float time)
    {
        int seconds = (int)(time += Time.deltaTime);
        //int seconds = (int)(time % 60f);

        text.text = seconds.ToString(); // +":" + seconds.ToString("00");
    }

    internal TextMeshProUGUI textMethod()
    {
        throw new NotImplementedException();
    }
}
