using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public DataContainer dataContainer;
    [SerializeField] TextMeshProUGUI coinsText;
    public int healthCost;
    public int damageCost;

    private void Awake()
    {

        LoadData();
        UpdateCoinsText();
    }

    public void Health()
    {
        if (ShopGameManager.Instance.dataContainer.coins >= healthCost)
        {
            ShopGameManager.Instance.dataContainer.coins -= healthCost;
            int maxHp = PlayerPrefs.GetInt("maxHp");
            int increase = Mathf.RoundToInt(maxHp * 0.1f);
            ShopGameManager.Instance.dataContainer.addedHealth += increase;
            SaveData();
            UpdateCoinsText();
        }
    }

    public void Damage()
    {
        if (ShopGameManager.Instance.dataContainer.coins >= damageCost)
        {
            ShopGameManager.Instance.dataContainer.coins -= damageCost;
            ShopGameManager.Instance.dataContainer.addedDamage += 100;
            SaveData();
            UpdateCoinsText();
        }
    }

    private void UpdateCoinsText()
    {
        coinsText.text = ShopGameManager.Instance.dataContainer.coins.ToString();
    }

    public void Reset()
    {
        ShopGameManager.Instance.dataContainer.coins = 0;
        ShopGameManager.Instance.dataContainer.addedHealth = 0;
        ShopGameManager.Instance.dataContainer.addedDamage = 0;
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
}
