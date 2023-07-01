using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useEldestWand : MonoBehaviour
{
    public GameObject wand;
    public bool coolDownOver = true;

    public void UseWand()
    {
        if (coolDownOver)
        {
            wand.SetActive(true);
        }
        
    }
}
