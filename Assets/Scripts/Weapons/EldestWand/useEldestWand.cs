using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class useEldestWand : MonoBehaviour
{
    public GameObject wand;
    public bool coolDownOver = true;
    public float timeLeft = 10.0f;
    public TextMeshProUGUI startText;

    public void UseWand()
    {
        if (coolDownOver)
        {
            wand.SetActive(true);
            timeLeft = 10.0f;
        }
        
    }

    private void Update()
    {
        startText.text = (timeLeft).ToString("0");
        if (!coolDownOver)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                coolDownOver = true;

            }
        }

    }
    public void StartTimer()
    {
        coolDownOver = false;
        
    }
}
