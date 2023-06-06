using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeWeapon : WeaponBase
{
    PlayerMovement playerMovement;

    [SerializeField] GameObject knifePrefab;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public override void Attack()
    {
        GameObject knife = Instantiate(knifePrefab);
        knife.transform.position = transform.position;
        knife.GetComponent<knifeProjectile>().SetDirection(playerMovement.lastHorizontalVector, 0f);
    }
}


