using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopManager : MonoBehaviour
{
    [SerializeField] DataContainer dataContainer;
    [SerializeField] TMPro.TextMeshProUGUI coins;
    public int cost;
    

    private void Awake()
    {
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coins.text = coinsAquired.ToString();

        PlayerPrefs.SetInt("addedHealth",dataContainer.addedHealth);
    }
    private void Update()
    {
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coins.text = coinsAquired.ToString(); 
    }

    public void Health()
    {
       
        if (dataContainer.coins >= cost)
        {
            int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
            
            dataContainer.coins -=cost;
            PlayerPrefs.SetInt("coinsAquired", dataContainer.coins);
            PlayerPrefs.Save();
            coins.text = coinsAquired.ToString();

            PlayerPrefs.GetInt("addedHealth");
            dataContainer.addedHealth += 100;
            PlayerPrefs.SetInt("addedHealth", dataContainer.addedHealth);
            PlayerPrefs.Save();

        }
        
    }
}
