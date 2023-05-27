using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour //weapons base class
{
    public WeaponData weaponData;
    public WeaponStats weaponStats;
    float timer;
    

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0f)
        {
           Attack();
            timer = weaponStats.timeToAttack;
        }
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.size);
    }

    public abstract void Attack(); //each weapon has to inherit and implement this method

    public virtual void PostMessage(int damage, Vector3 targetPos)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPos);
    }

    internal void Upgrade(UpgradeData upgradeData)
    {
        this.weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }
}
