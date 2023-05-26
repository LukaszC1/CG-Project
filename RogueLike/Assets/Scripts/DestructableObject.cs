using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, iDamageable
{
    private bool tookDamage = false;
    public bool TookDamage { get => tookDamage; set => tookDamage = value; }



    public void ApplySlow()
    {
        return;
    }

    public void TakeDamage(float damage)
    {
        Destroy(gameObject);
        GetComponent<DropOnDestroy>().CheckDrop();
    }
}
