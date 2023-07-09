using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI coins;

    private void Awake()
    {
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coins.text = coinsAquired.ToString();
    }
}
