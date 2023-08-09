using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArcher : MonoBehaviour
{
    public Transform player;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float runSpeed = 5f;
    public float shootingCooldown = 2f;
    public float shootingRange = 10f;
    public float arrowSpeed = 10f;

    private Animator animator;
    private bool canShoot = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer > shootingRange)
            {
                MoveTowardsPlayer();
            }
            else
            {
                StopRunning();
                TryShootArrow();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, runSpeed * Time.deltaTime);
        animator.SetBool("Running", true);
    }

    private void StopRunning()
    {
        animator.SetBool("Running", false);
    }

    private void TryShootArrow()
    {
        if (canShoot)
        {
            ShootArrow();
            StartCoroutine(ShootingCooldown());
        }
    }

    private void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
        Vector2 direction = (player.position - arrowSpawnPoint.position).normalized;
        arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowSpeed;
        animator.SetTrigger("Attack");
    }

    private IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingCooldown);
        canShoot = true;
    }
}