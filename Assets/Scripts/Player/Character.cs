using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000 ;
    public int currentHp = 1000;
    public int armour = 0;
    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }

    public void TakeDamage(int damage)
    {
        ApplyArmour(ref damage);

        currentHp -= damage;

        if(currentHp <= 0)
        {
            Debug.Log("CharacterDEAD");
        }
        hpBar.SetState(currentHp, maxHp);
    }

    private void ApplyArmour(ref int damage)
    {
        damage -= armour;
        if (damage < 0 ) { damage = 0; }
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0) { return; }

        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
}
