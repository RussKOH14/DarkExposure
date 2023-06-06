using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
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

        if (hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperince(experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }
}
