using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armour;

    internal void Sum(ItemStats stats)
    {
        armour += stats.armour;
    }
}
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public ItemStats stats;
    public List<UpgradeData> upgrades;

    public void Init(string Name)
    {
        this.Name = Name;
        stats = new ItemStats();
        upgrades = new List<UpgradeData>();
    }

    public void Equip(Character character)
    {
        character.armour += stats.armour;
    }
    public void UnEquip(Character character)
    {
        character.armour -= stats.armour;
    }


}
