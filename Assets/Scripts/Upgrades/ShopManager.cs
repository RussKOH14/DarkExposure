using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ShopManager : MonoBehaviour
{
    public DataContainer dataContainer;
    [SerializeField] TextMeshProUGUI coinsText;
    public int healthCost;
    public int damageCost;
    public int speedCost;

    public UnityEngine.UI.Button healthButton;
    public Sprite healthCopper;
    public Sprite healthSilver;
    public Sprite healthGold;
    public Sprite healthAmethyst;

    private void Awake()
    {
        LoadData();
        UpdateCoinsText();
    }
    private void Update()
    {
        if(ShopGameManager.Instance.dataContainer.healthUpgrades == 0)
        {
            healthButton.GetComponent<Image>().sprite = healthCopper;
        }
        if(ShopGameManager.Instance.dataContainer.healthUpgrades == 1)
        {
            healthButton.GetComponent<Image>().sprite = healthSilver;
        }
        if(ShopGameManager.Instance.dataContainer.healthUpgrades == 2)
        {
            healthButton.GetComponent<Image>().sprite = healthGold;
        }
        if(ShopGameManager.Instance.dataContainer.healthUpgrades == 3)
        {
            healthButton.GetComponent<Image>().sprite = healthAmethyst;
        }
    }

    public void Health()
    {
        if (ShopGameManager.Instance.dataContainer.healthUpgrades < 4)
        {
            if (ShopGameManager.Instance.dataContainer.coins >= healthCost)
            {
                ShopGameManager.Instance.dataContainer.healthUpgrades += 1;
                ShopGameManager.Instance.dataContainer.coins -= healthCost;
                int maxHp = PlayerPrefs.GetInt("maxHp");
                int increase = Mathf.RoundToInt(maxHp * 0.1f);
                ShopGameManager.Instance.dataContainer.addedHealth += increase;
                SaveData();
                UpdateCoinsText();
                Debug.Log("health");
            }
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

    public void Speed()
    {
        if (ShopGameManager.Instance.dataContainer.coins >= speedCost)
        {
            ShopGameManager.Instance.dataContainer.coins -= speedCost;
            int originalSpeed = PlayerPrefs.GetInt("originalSpeed");
            int speedIncrease = Mathf.RoundToInt(originalSpeed * 0.1f);
            ShopGameManager.Instance.dataContainer.speed += speedIncrease;
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
        ShopGameManager.Instance.dataContainer.healthUpgrades = 0;
        ShopGameManager.Instance.dataContainer.addedDamage = 0;
        ShopGameManager.Instance.dataContainer.speed = 0;
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
