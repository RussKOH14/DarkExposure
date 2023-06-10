using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int armour;

    public void Equip(Character character)
    {
        character.armour += armour;
    }
    public void UnEquip(Character character)
    {
        character.armour -= armour;
    }


}
