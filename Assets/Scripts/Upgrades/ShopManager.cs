using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI coinsText;
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
            ShopGameManager.Instance.dataContainer.addedHealth += 100;
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


    private void LoadData()
    {
        ShopGameManager.Instance.LoadData();
    }

    private void SaveData()
    {
        ShopGameManager.Instance.SaveData();
    }
}
