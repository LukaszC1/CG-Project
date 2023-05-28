using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
  
    [SerializeField] GameObject rightWhipObject;
    [SerializeField] GameObject leftWhipObject;

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i=0; i < colliders.Length; i++)
        {
            iDamageable e = colliders[i].GetComponent<iDamageable>();
            if (e != null)
            {
                PostMessage((int)weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    public override void Attack()
    {
     
        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, weaponStats.vectorSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, weaponStats.vectorSize, 0f);
            ApplyDamage(colliders);
        }
    }
}
