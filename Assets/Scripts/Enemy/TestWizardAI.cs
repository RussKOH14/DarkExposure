using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWizardAI : MonoBehaviour

{
    public Transform player;
    public float movementSpeed = 3f;
    public float stoppingRadius = 2f;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check the direction of the player
        if (player.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }
        else if (player.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }

        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Move towards the player only if the distance is greater than the stopping radius
        if (distanceToPlayer > stoppingRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * movementSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}