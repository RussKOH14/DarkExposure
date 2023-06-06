using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    PlayerMovement playerMovement;

    [SerializeField] GameObject knifePrefab;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    private void Update()
    {
        if(timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        GameObject knife = Instantiate(knifePrefab);
        knife.transform.position = transform.position;
        knife.GetComponent<knifeProjectile>().SetDirection(playerMovement.lastHorizontalVector, 0f);
    }
}


