using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform targetDestination;
    [SerializeField] private float speed;

    public Rigidbody2D rgdbd2d;
    

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
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
        Debug.Log("Attacking The Player");
    }
}
