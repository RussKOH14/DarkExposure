using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armour;
    public float magnetRadiusAddition;
    public bool canUseManualWeapon;
    public float canUseSkulls;


    internal void Sum(ItemStats stats)
    {
        armour += stats.armour;
        magnetRadiusAddition += stats.magnetRadiusAddition;
        canUseSkulls += stats.canUseSkulls;
        
    }
    
}
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public ItemStats stats;
    public List<UpgradeData> upgrades;

    public Magnet magnet;

    private void Awake()
    {
        magnet = FindObjectOfType<Magnet>();
    }


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
        character.canUseManualWeapon = stats.canUseManualWeapon;
        character.canUseSkulls += stats.canUseSkulls;
    }
    public void UnEquip(Character character)
    {
        character.armour -= stats.armour;
        character.colliderSize -= stats.magnetRadiusAddition;
        character.canUseManualWeapon = stats.canUseManualWeapon;
        character.canUseSkulls -= stats.canUseSkulls;
    }


}
