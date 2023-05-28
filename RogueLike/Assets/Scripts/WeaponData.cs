using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public float damage;
    public float timeToAttack;
    public float size;
    public Vector2 vectorSize;

    //weapon attributes

    public WeaponStats(float damage, float timeToAttack, float size, Vector2 vectorSize)
    {
        this.damage = damage;   
        this.timeToAttack = timeToAttack;
        this.size = size;
        this.vectorSize = vectorSize;
    }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.size += weaponUpgradeStats.size;
        this.vectorSize += weaponUpgradeStats.vectorSize;
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
