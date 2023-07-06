using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armour;
    public float magnetRadiusAddition;
    public float canUseManualWeapon;
    public float canUseSkulls;
    public int skullCount;


    internal void Sum(ItemStats stats)
    {
        armour += stats.armour;
        magnetRadiusAddition += stats.magnetRadiusAddition;
        canUseManualWeapon += stats.canUseManualWeapon;
        canUseSkulls += stats.canUseSkulls;
        skullCount += stats.skullCount;
        
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
        character.colliderSize += stats.magnetRadiusAddition;
        character.canUseManualWeapon += stats.canUseManualWeapon;
        character.canUseSkulls += stats.canUseSkulls;
        character.skullCount += stats.skullCount;
    }
    public void UnEquip(Character character)
    {
        character.armour -= stats.armour;
        character.colliderSize -= stats.magnetRadiusAddition;
        character.canUseManualWeapon -= stats.canUseManualWeapon;
        character.canUseSkulls -= stats.canUseSkulls;
        character.skullCount -= stats.skullCount;
    }


}
