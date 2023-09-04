using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public static int maxHp = 500 ;
    public int currentHp = 500;

    public int armour = 0;

    public float hpRegenerationRate = 1f;
    public float hpRegenerationTimer;

    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    
    private bool isDead;
    
    [Header("Magnet")]
    public Magnet magnet;
    public float colliderSize;

    [Header("Manual Wand")]
    public float canUseManualWeapon = 0f;
    public GameObject buttonManualWeapon;

    [Header("Skulls")]
    public float canUseSkulls = 0f;
    Skulls skullController;
    public int skullCount = 0;
    private int oldSkullCount;

    [Header("Cheese Rush")]
    public GameObject remy;
    public int hasRemy;
    public int hasCheese;

    private void Awake()
    {
        int addedHealth = PlayerPrefs.GetInt("addedHealth");
        maxHp = maxHp + addedHealth;
        PlayerPrefs.SetInt("maxHp", maxHp);
        PlayerPrefs.Save();

        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
        magnet = FindObjectOfType<Magnet>();
        skullController = FindObjectOfType<Skulls>();
        skullCount += skullController.upgradeLevel;
    }

    private void Start()
    {
        UpdateHpBar();
        hasRemy = 0;
        hasCheese = 0;
        oldSkullCount = 1;
    }

    private void Update()
    {
        if (skullController.usingSkulls)
        {
            if (skullCount > oldSkullCount)
            {
                skullController.upgradeLevel = skullCount;
                skullController.HandleUpgrade();
                oldSkullCount = skullCount;
            }
           
        }
        
        magnet.magnetCollider.radius += colliderSize;
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;

        if (hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }

        UpdateHpBar();
       
        if (hasRemy >= 1)
        {
            remy.SetActive(true);
        }

    }


    public void TakeDamage(int damage)
    {
        if (isDead) { return; }

        currentHp -= damage;

        if (currentHp <= 0)
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }

        UpdateHpBar();
    }

    private void UpdateHpBar()
    {
        int currentMaxHp = maxHp + armour; // Calculate current max HP with added armor
        hpBar.SetState(currentHp, currentMaxHp);
    }


    public void Heal(int amount)
    {
        if (currentHp <= 0) { return; }

        currentHp += amount;
        if (currentHp > maxHp + armour)
        {
            currentHp = maxHp + armour;
        }
    }
}
