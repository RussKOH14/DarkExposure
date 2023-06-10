using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager upgradePanel;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selecetedUpgrade;

    [SerializeField] List<UpgradeData> acquiredUpgrades;

    WeaponManager weaponManager;
    PassiveItems passiveItems;

    [SerializeField] List<UpgradeData> upgradesAvvailableOnStart;

    public int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        passiveItems = GetComponent<PassiveItems>();
    }

    internal void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        if(upgradesToAdd == null)
        {
            return;
        }
        this.upgrades.AddRange(upgradesToAdd);
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
        AddUpgradesIntoTheListOfAvailableUpgrades(upgradesAvvailableOnStart);
    }

    public void AddExperince(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience,TO_LEVEL_UP);
    }

    public void Upgrade(int selecetedUpgradeID)
    {
        UpgradeData upgradeData = selecetedUpgrade[selecetedUpgradeID]; 

        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.ItemUpgrade:
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUnlock:
                passiveItems.Equip(upgradeData.item);
                break;
        }

        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if(selecetedUpgrade == null) { selecetedUpgrade = new List<UpgradeData>(); }
        selecetedUpgrade.Clear();
        selecetedUpgrade.AddRange(GetUpgrades(3));

        upgradePanel.OpenPanel(selecetedUpgrade);
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }
}
