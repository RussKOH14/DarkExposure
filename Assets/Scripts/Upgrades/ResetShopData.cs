using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetShopData : MonoBehaviour
{
    public DataContainer dataContainer;


    private void Awake()
    {
        LoadData();
        UpdateCoinsText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        ShopGameManager.Instance.dataContainer.coins = 0;
        ShopGameManager.Instance.dataContainer.addedHealth = 0;
        ShopGameManager.Instance.dataContainer.healthUpgrades = 0;
        ShopGameManager.Instance.dataContainer.addedDamage = 0;
        ShopGameManager.Instance.dataContainer.damageUpgrades = 0;
        ShopGameManager.Instance.dataContainer.speed = 0;
        ShopGameManager.Instance.dataContainer.speedUpgrades = 0;
        ShopGameManager.Instance.dataContainer.tutorial = 0;
        SaveData();
        UpdateCoinsText();
    }
    private void LoadData()
    {
        ShopGameManager.Instance.LoadData();
    }

    private void SaveData()
    {
        ShopGameManager.Instance.SaveData();
    }
    private void UpdateCoinsText()
    {
        //coinsText.text = ShopGameManager.Instance.dataContainer.coins.ToString();
    }
}
