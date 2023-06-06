using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject dropItemPickup;
    [SerializeField] [Range(0f, 1f)] float chance = 1f;

    public void CheckDrop()
    {
        if(Random.value < chance)
        {
            Transform t = Instantiate(dropItemPickup).transform;
            t.position = transform.position;
        }
    }
}
