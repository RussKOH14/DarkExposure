using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UpgradeDisplay : MonoBehaviour
{
    public List<Transform> upgradeSlotsParent;
    public List<Transform> weaponSlotsParent;
    public GameObject upgradeSlotPrefab; 
    public Item upgradeItem;
    
    Level level;

    private void Start()
    {
        //DisplayUpgrade(upgradeItem);
        level = FindObjectOfType<Level>();
    }

    public void DisplayUpgrade(Item upgrade)
    {
        if (upgradeSlotsParent != null)
        {
            GameObject slot = Instantiate(upgradeSlotPrefab, upgradeSlotsParent[0]);
            Image slotImage = slot.GetComponent<Image>();

            if (upgrade.upgrades.Count > 0)
            {
                Sprite upgradeIcon = upgrade.upgrades[0].icon;
                slotImage.sprite = upgradeIcon;
            }
        }

    }  
    public void DisplayWeapon(Item upgrade)
    {
        if(weaponSlotsParent != null)
        {
            GameObject slot = Instantiate(upgradeSlotPrefab, weaponSlotsParent[0]);
            Image slotImage = slot.GetComponent<Image>();

            if (upgrade.upgrades.Count > 0)
            {
                Sprite upgradeIcon = upgrade.upgrades[0].icon;
                slotImage.sprite = upgradeIcon;
            }
        }
    }
}
