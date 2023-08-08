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

    public AudioSource error;

    [Header("Health Buttons")]
    public UnityEngine.UI.Button healthButton;
    public Sprite healthCopper;
    public Sprite healthSilver;
    public Sprite healthGold;
    public Sprite healthAmethyst;
    
    [Header("Damage Buttons")]
    public UnityEngine.UI.Button damageButtons;
    public Sprite damageCopper;
    public Sprite damageSilver;
    public Sprite damageGold;
    public Sprite damageAmethyst;
    
    [Header("Speed Buttons")]
    public UnityEngine.UI.Button speedButtons;
    public Sprite speedCopper;
    public Sprite speedSilver;
    public Sprite speedGold;
    public Sprite speedAmethyst;



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
        
        
        
        if(ShopGameManager.Instance.dataContainer.damageUpgrades == 0)
        {
            damageButtons.GetComponent<Image>().sprite = damageCopper;
        }
        if(ShopGameManager.Instance.dataContainer.damageUpgrades == 1)
        {
            damageButtons.GetComponent<Image>().sprite = damageSilver;
        }
        if(ShopGameManager.Instance.dataContainer.damageUpgrades == 2)
        {
            damageButtons.GetComponent<Image>().sprite = damageGold;
        }
        if(ShopGameManager.Instance.dataContainer.damageUpgrades == 3)
        {
            damageButtons.GetComponent<Image>().sprite = damageAmethyst;
        }
        
        
        if(ShopGameManager.Instance.dataContainer.speedUpgrades == 0)
        {
            speedButtons.GetComponent<Image>().sprite = speedCopper;
        }
        if(ShopGameManager.Instance.dataContainer.speedUpgrades == 1)
        {
            speedButtons.GetComponent<Image>().sprite = speedSilver;
        }
        if(ShopGameManager.Instance.dataContainer.speedUpgrades == 2)
        {
            speedButtons.GetComponent<Image>().sprite = speedGold;
        }
        if(ShopGameManager.Instance.dataContainer.speedUpgrades == 3)
        {
            speedButtons.GetComponent<Image>().sprite = speedAmethyst;
        }
    }

    public void Health()
    {
        if (ShopGameManager.Instance.dataContainer.healthUpgrades < 3)
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

        else
        {
            error.Play();
        }
       
    }

    public void Damage()
    {
        if (ShopGameManager.Instance.dataContainer.damageUpgrades < 3)
        {
            if (ShopGameManager.Instance.dataContainer.coins >= damageCost)
            {
                ShopGameManager.Instance.dataContainer.damageUpgrades += 1;
                ShopGameManager.Instance.dataContainer.coins -= damageCost;
                ShopGameManager.Instance.dataContainer.addedDamage += 100;
                SaveData();
                UpdateCoinsText();
            }
        }

        else
        {
            error.Play();
        }
    }

    public void Speed()
    {
        if (ShopGameManager.Instance.dataContainer.speedUpgrades < 3)
        {
            if (ShopGameManager.Instance.dataContainer.coins >= speedCost)
            {
                ShopGameManager.Instance.dataContainer.speedUpgrades += 1;
                ShopGameManager.Instance.dataContainer.coins -= speedCost;
                int originalSpeed = PlayerPrefs.GetInt("originalSpeed");
                int speedIncrease = Mathf.RoundToInt(originalSpeed * 0.1f);
                ShopGameManager.Instance.dataContainer.speed += speedIncrease;
                SaveData();
                UpdateCoinsText();
            }
        }

        else
        {
            error.Play();
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
