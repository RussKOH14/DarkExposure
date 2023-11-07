using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // References to external objects and variables
    public DataContainer dataContainer; // Data container for storing game data
    [SerializeField] TextMeshProUGUI coinsText; // Text display for the number of coins
    public int healthCost; // Cost of health upgrades
    public int damageCost; // Cost of damage upgrades
    public int speedCost; // Cost of speed upgrades
    public AudioSource error; // Sound to play on errors

    // References to buttons and their associated sprites
    [Header("Health Buttons")]
    public Button healthButton; // Button for health upgrades
    public Sprite[] healthSprites; // Array of health upgrade sprites

    [Header("Damage Buttons")]
    public Button damageButtons; // Button for damage upgrades
    public Sprite[] damageSprites; // Array of damage upgrade sprites

    [Header("Speed Buttons")]
    public Button speedButtons; // Button for speed upgrades
    public Sprite[] speedSprites; // Array of speed upgrade sprites

    // References to lock images
    [Header("Locks")]
    public Image strengthLock; // Lock for strength upgrades
    public Image speedLock; // Lock for speed upgrades

    private void Awake()
    {
        LoadData(); // Load saved game data
        UpdateCoinsText(); // Update the displayed number of coins
    }

    private void Update()
    {
        UpdateLocks(); // Update the visibility of locks
        UpdateUpgradeButtonSprite(healthButton, dataContainer.healthUpgrades, healthSprites); // Update health upgrade button sprite
        UpdateUpgradeButtonSprite(damageButtons, dataContainer.damageUpgrades, damageSprites); // Update damage upgrade button sprite
        UpdateUpgradeButtonSprite(speedButtons, dataContainer.speedUpgrades, speedSprites); // Update speed upgrade button sprite
    }

    private void UpdateLocks()
    {
        strengthLock.enabled = dataContainer.strengthUnlocked < 1; // Show or hide strength lock based on unlock status
        speedLock.enabled = dataContainer.speedUnlocked < 1; // Show or hide speed lock based on unlock status
    }

    private void UpdateUpgradeButtonSprite(Button button, int upgradeLevel, Sprite[] upgradeSprites)
    {
        if (upgradeLevel >= 0 && upgradeLevel < upgradeSprites.Length)
        {
            button.GetComponent<Image>().sprite = upgradeSprites[upgradeLevel]; // Update the button sprite based on the upgrade level
        }
    }

    // Methods for handling health, damage, speed upgrades
    // ...

    private void UpdateCoinsText()
    {
        coinsText.text = ShopGameManager.Instance.dataContainer.coins.ToString(); // Update the displayed number of coins
    }

    private void LoadData()
    {
        ShopGameManager.Instance.LoadData(); // Load saved game data
    }

    private void SaveData()
    {
        ShopGameManager.Instance.SaveData(); // Save the game data
    }
}

