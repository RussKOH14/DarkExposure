using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;

public class Enemy : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;      //Player info

    public Rigidbody2D rgdbd2d;     //enemy rigidbody

    [SerializeField] private float speed;
    [SerializeField] int hp = 4;
    [SerializeField] int damage = 1;
    [SerializeField] int experience_reward = 400;   //enemy stats (can be changed in inspector)

    UseManualWeapon useManualWeapon;      //manual weapon script
    public GameObject gameManager;       //manual weapon script is in game manager

    EnemyKilledScore enemyKilledScore;      //player's score script

    private SpriteRenderer spriteRenderer;  //enemy sprite renderer
    private Color originalColor;            //original colour of the enemy

    private void Awake()    //calling all the following components
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        enemyKilledScore = FindObjectOfType<EnemyKilledScore>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        gameManager = GameObject.Find("--GAMEMANAGER--");
        useManualWeapon = gameManager.GetComponent<UseManualWeapon>();
    }

    public void SetTarget(GameObject target)    //Sets the enemy's taret to the player character
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        if (targetDestination != null)      //if the enemy has a target...
            {
                Vector3 direction = (targetDestination.position - transform.position).normalized; // Calculate the direction to the target

                if (direction.x < 0)
                    transform.localScale = new Vector3(-1, 1, 1);
                else if (direction.x > 0)
                    transform.localScale = new Vector3(1, 1, 1);        // Flip the enemy sprite based on the target's position

                rgdbd2d.velocity = direction * speed;         // Move towards the target
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))      //if enemy makes contact with the character
        {
            Attack();   //calls attack method
        }
    }

    private void Attack()
    {
       if(targetCharacter == null)     //just in case target character hasn't already been called (it should be, this is just in case)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();   //calls target character
        }
        targetCharacter.TakeDamage(damage);     //calls damage method to apply damage to CHARACTER NOT ENEMY
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;   //applies damage to enemy

        Vector3 knockbackDirection = (transform.position - targetGameObject.transform.position).normalized;
        transform.position += knockbackDirection * 0.9f;        // Apply knockback force

        StartCoroutine(FlashRed());       //starts coroutine for enemy damage flash effect

        if (hp < 1)     //if enemy runs out of health
        {
            targetGameObject.GetComponent<Level>().AddExperince(experience_reward); //gives player exp
            GetComponent<DropOnDestroy>().CheckDrop();      //drops a pickup
            Destroy(gameObject);        //destroys enemy
            enemyKilledScore.enemiesKilled += 1;        //adds to player score
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(0))        //if the player clicks left mouse button
        {
            if (collision.CompareTag("ManualWeapon"))     //if enemy is in manual weapon collider
            {
                targetGameObject.GetComponent<Level>().AddExperince(experience_reward);     //gives player exp
                GetComponent<DropOnDestroy>().CheckDrop();      //drops a pickup
                Destroy(gameObject);        //destroys enemy
                collision.gameObject.SetActive(false);      //turns off manual weapon collider
                useManualWeapon.StartTimer();   //starts manual weapon cooldown
            }
        }
    }
    private IEnumerator FlashRed()      //coroutine for enemy damage flash effect
    {
        spriteRenderer.color = Color.red;       
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;       //makes enemy flash red then return to origial colour
    }
}

