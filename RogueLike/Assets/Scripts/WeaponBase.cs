using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour //weapons base class
{
    public WeaponData weaponData;
    public WeaponStats weaponStats;
    public float timeToAttack = 1f;
    float timer;
    

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0f)
        {
           Attack();
            timer = timeToAttack;
        }
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        timeToAttack = wd.stats.timeToAttack;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.size);
    }

    public abstract void Attack(); //each weapon has to inherit and implement this method
   
}
