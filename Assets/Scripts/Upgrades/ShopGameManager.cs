using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGameManager : MonoBehaviour
{
 
    public static ShopGameManager Instance;


    public DataContainer dataContainer;
    

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        LoadData();
    }


    public void LoadData()
    {
        dataContainer.coins = PlayerPrefs.GetInt("coinsAquired", dataContainer.coins);
        dataContainer.addedHealth = PlayerPrefs.GetInt("addedHealth", dataContainer.addedHealth);
        dataContainer.healthUpgrades = PlayerPrefs.GetInt("healthUpgrades", dataContainer.healthUpgrades);
        dataContainer.addedDamage = PlayerPrefs.GetInt("addedDamage", dataContainer.addedDamage);
        dataContainer.damageUpgrades = PlayerPrefs.GetInt("damageUpgrades", dataContainer.damageUpgrades);
        dataContainer.speed = PlayerPrefs.GetInt("speed", dataContainer.speed);
        dataContainer.speedUpgrades = PlayerPrefs.GetInt("speedUpgrades", dataContainer.speedUpgrades);

    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsAquired", dataContainer.coins);
        PlayerPrefs.SetInt("addedHealth", dataContainer.addedHealth);
        PlayerPrefs.SetInt("healthUpgrades", dataContainer.healthUpgrades);
        PlayerPrefs.SetInt("addedDamage", dataContainer.addedDamage);
        PlayerPrefs.SetInt("damageUpgrades", dataContainer.damageUpgrades);
        PlayerPrefs.SetInt("speed", dataContainer.speed);
        PlayerPrefs.SetInt("speedUpgrades", dataContainer.speedUpgrades);
        PlayerPrefs.Save();
    }
}
