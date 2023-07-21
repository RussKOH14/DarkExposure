using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopManager : MonoBehaviour
{
    [SerializeField] DataContainer dataContainer;
    [SerializeField] TMPro.TextMeshProUGUI coins;
    public int healthCost;
    public int damageCost;
    
    private void Awake()
    {
        PlayerPrefs.SetInt("coinsAquired", dataContainer.coins);
        PlayerPrefs.Save();
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coins.text = coinsAquired.ToString();

        PlayerPrefs.SetInt("addedHealth",dataContainer.addedHealth);
        PlayerPrefs.SetInt("addedDamage",dataContainer.addedDamage);
    }
    private void Update()
    {
        PlayerPrefs.SetInt("coinsAquired", dataContainer.coins);
        PlayerPrefs.Save();
        int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
        coins.text = coinsAquired.ToString(); 
    }

    public void Health()
    {
        if (dataContainer.coins >= healthCost)
        {
            int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
            
            dataContainer.coins -=healthCost;
            PlayerPrefs.SetInt("coinsAquired", dataContainer.coins);
            PlayerPrefs.Save();
            coins.text = coinsAquired.ToString();

            PlayerPrefs.GetInt("addedHealth");
            dataContainer.addedHealth += 100;
            PlayerPrefs.SetInt("addedHealth", dataContainer.addedHealth);
            PlayerPrefs.Save();

        }
        
    }
    public void Damage()
    {
        
        if (dataContainer.coins >= damageCost)
        {
            Debug.Log("worked");
            int coinsAquired = PlayerPrefs.GetInt("coinsAquired");
            
            dataContainer.coins -=damageCost;
            PlayerPrefs.SetInt("coinsAquired", dataContainer.coins);
            PlayerPrefs.Save();
            coins.text = coinsAquired.ToString();

            PlayerPrefs.GetInt("addedDamage");
            dataContainer.addedDamage += 100;
            PlayerPrefs.SetInt("addedDamage", dataContainer.addedDamage);
            PlayerPrefs.Save();

        }
        
    }
}
