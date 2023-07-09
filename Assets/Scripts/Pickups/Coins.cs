using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] int dataCoins;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    private void Awake()
    {
        dataCoins = DataContainer.coins; 
        coinsCountText.text = dataCoins.ToString();
    }
    public void Add (int count)
    {
        dataCoins += count;
        coinsCountText.text = dataCoins.ToString();
    }
    
}
