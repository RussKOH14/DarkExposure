using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{
    public GameObject skullPrefab;   // Reference to the skull prefab
    public float throwForce = 5f;    // The initial force to throw the skull
    public float horizontalForce = 2f; // The force to move the skull horizontally
    public float spinForce = 100f;    // The force to make the skull spin

    private void Update()
    {
        // Check if the player throws the skull
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowSkull();
        }
    }

    private void ThrowSkull()
    {
        // Instantiate the skull prefab
        GameObject skull = Instantiate(skullPrefab, transform.position, Quaternion.identity);

        // Determine the direction to throw (left or right)
        float throwDirection = transform.localScale.x > 0 ? 1f : -1f;

        // Get the skull's Rigidbody2D component
        Rigidbody2D skullRb = skull.GetComponent<Rigidbody2D>();

        // Apply the throw force
        skullRb.velocity = new Vector2(throwDirection * throwForce, throwForce);

        // Apply random horizontal force
        float randomHorizontalForce = Random.Range(-horizontalForce, horizontalForce);
        skullRb.AddForce(new Vector2(randomHorizontalForce, 0f), ForceMode2D.Impulse);

        // Apply spin force
        skullRb.angularVelocity = Random.Range(-spinForce, spinForce);
    }
}
