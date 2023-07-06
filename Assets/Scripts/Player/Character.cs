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
    public Magnet magnet;
    public float colliderSize;

    public bool canUseManualWeapon;
    public GameObject buttonManualWeapon;

    public float canUseSkulls = 0f;
    SkullController skullController;
    public int skullCount;

    [SerializeField] TextMeshProUGUI healthText;
    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
        magnet = FindObjectOfType<Magnet>();
        skullController = FindObjectOfType<SkullController>();
        skullCount = skullController.skullCount;

    }

    private void Start()
    {
        UpdateHpBar();
        canUseManualWeapon = false;
        //canUseSkulls = 0f;
    }

    private void Update()
    {
        magnet.magnetCollider.radius += colliderSize;
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;

        if (hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }

        UpdateHpBar();
        UpdateHealthText();

        if (canUseManualWeapon)
        {
            buttonManualWeapon.SetActive(true);
        }
        else
        {
            buttonManualWeapon.SetActive(false);
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

    private void UpdateHealthText()
    {
        string formattedText = $"{currentHp} / {maxHp + armour}";
        healthText.text = formattedText;
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
