using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] DataContainer dataContainer;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    private void Awake()
    {
        PlayerPrefs.SetInt("coinsAquired", dataContainer.coins);
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coinsCountText.text = coinsAquired.ToString();
        
    }
    private void Update()
    {
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coinsCountText.text = coinsAquired.ToString();
        if (dataContainer.coins < 0)
        {
            dataContainer.coins = 0;
        }
    }
    public void Add (int count)
    {
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coinsCountText.text = coinsAquired.ToString();
        dataContainer.coins += count;
        PlayerPrefs.SetInt("coinsAquired", dataContainer.coins);
        PlayerPrefs.Save();
    }
    
}
