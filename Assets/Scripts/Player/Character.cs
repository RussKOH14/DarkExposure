using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public int maxHp = 1000 ;
    public int currentHp = 1000;

    public int armour = 0;

    public float hpRegenerationRate = 1f;
    public float hpRegenerationTimer;

    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    private bool isDead;


    [SerializeField] TextMeshProUGUI healthText; 
    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
        
    }

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
        
    }

    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;

        if (hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }
        hpBar.SetState(currentHp, maxHp);

        string formattedText = $"{currentHp} / {maxHp}";
        healthText.text = formattedText;

    }
    public void TakeDamage(int damage)
    {
        if (isDead == true) { return; }
        ApplyArmour(ref damage);

        currentHp -= damage;

        if(currentHp <= 0)
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
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
