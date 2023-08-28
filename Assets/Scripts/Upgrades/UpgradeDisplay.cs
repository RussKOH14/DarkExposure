using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplay : MonoBehaviour
{
    public Transform upgradeSlotsParent; // Assign the parent transform of your upgrade slots in the Inspector.
    public GameObject upgradeSlotPrefab; // Assign the upgrade slot prefab in the Inspector.
    public Item upgradeItem; // Assign the Item scriptable object for the upgrade in the Inspector.

    private void Start()
    {
        DisplayUpgrade(upgradeItem);
    }

    public void DisplayUpgrade(Item upgrade)
    {
        GameObject slot = Instantiate(upgradeSlotPrefab, upgradeSlotsParent);
        Image slotImage = slot.GetComponent<Image>();

        if (upgrade.upgrades.Count > 0)
        {
            Sprite upgradeIcon = upgrade.upgrades[0].icon;
            slotImage.sprite = upgradeIcon;
        }
    }
}
