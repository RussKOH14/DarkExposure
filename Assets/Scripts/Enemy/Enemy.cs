using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_CLOUD_SERVICES_ANALYTICS
using UnityEngine.Analytics;
using TMPro;
#endif

public class Enemy : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;

    public Rigidbody2D rgdbd2d;

    [SerializeField] private float speed;
    [SerializeField] int hp = 4;
    [SerializeField] int damage = 1;
    [SerializeField] int experience_reward = 400;

    UseManualWeapon useEldestWand;
    public GameObject gameManager;

    EnemyKilledScore enemyKilledScore;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        enemyKilledScore = FindObjectOfType<EnemyKilledScore>();
    }
    private void Start()
    {
        gameManager = GameObject.Find("--GAMEMANAGER--");
        useEldestWand = gameManager.GetComponent<UseManualWeapon>();
        
    }   

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
    if (targetDestination != null)
        {
        // Calculate the direction to the target
        Vector3 direction = (targetDestination.position - transform.position).normalized;

        // Flip the enemy sprite based on the target's position
        if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);

        // Move towards the target
        rgdbd2d.velocity = direction * speed;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        // Apply knockback force
        Vector3 knockbackDirection = (transform.position - targetGameObject.transform.position).normalized;
        transform.position += knockbackDirection * 0.9f;


        if (hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperince(experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
            enemyKilledScore.enemiesKilled += 1;
            //analytics
#if ENABLE_CLOUD_SERVICES_ANALYTICS
            Analytics.CustomEvent("enemyKilled");
            Debug.Log("fired event");
#endif


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(0))
        {
            
            if (collision.CompareTag("EldestWand"))
            {
                targetGameObject.GetComponent<Level>().AddExperince(experience_reward);
                GetComponent<DropOnDestroy>().CheckDrop();
                Destroy(gameObject);
                Debug.Log("fired event");

                collision.gameObject.SetActive(false);
                useEldestWand.StartTimer();

            }
            
        }
    }
}
