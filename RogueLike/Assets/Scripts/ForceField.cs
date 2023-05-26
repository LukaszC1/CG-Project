using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    [SerializeField] float timeToAttack = 1f;
    float timer, slowTimer = 0.1f;
    [SerializeField] float forceFieldSize = 1;
    [SerializeField] int forceFieldDamage = 1;

    private void Update()
    {
        timer -= Time.deltaTime;
        slowTimer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
        if (slowTimer < 0f)
        {
            Slow();
        }
        firstAttack();
    }

    private void Attack()
    {
        timer = timeToAttack;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, forceFieldSize);
        ApplyDamage(colliders);
    }

    private void Slow()
    {
        slowTimer = 0.1f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, forceFieldSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            iDamageable e = colliders[i].GetComponent<iDamageable>();
            if (e != null)
            {
                e.ApplySlow(); 
            }
        }
    }

    private void firstAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, forceFieldSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            iDamageable e = colliders[i].GetComponent<iDamageable>();
            if (e != null && e.TookDamage==false)
            {
                e.TakeDamage(forceFieldDamage);
                e.ApplySlow();
                e.TookDamage = true;
            }
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            iDamageable e = colliders[i].GetComponent<iDamageable>();
            if (e != null)
            {
                e.TakeDamage(forceFieldDamage);
            }  
        }
    }
}
