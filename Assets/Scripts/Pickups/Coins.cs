using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] DataContainer dataContainer;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    private void Awake()
    {
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coinsCountText.text = coinsAquired.ToString();
        
    }
    private void Update()
    {
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coinsCountText.text = coinsAquired.ToString();
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
