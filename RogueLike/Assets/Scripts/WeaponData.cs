using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public float size;

    //weapon attributes

    public WeaponStats(int damage, float timeToAttack, float size)
    {
        this.damage = damage;   
        this.timeToAttack = timeToAttack;
        this.size = size;
    }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.size += weaponUpgradeStats.size;
    }
}
[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public UpgradeData firstUpgrade;
}
