using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI descriptionText; // Use TextMeshProUGUI for TextMeshPro support

    public void Set(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.icon;
        descriptionText.text = upgradeData.description; // Set the upgrade description text
    }

    internal void Clean()
    {
        icon.sprite = null;
        descriptionText.text = string.Empty; // Clear the upgrade description text
    }
}