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
    [SerializeField] EnemiesManager enemiesManager;

    //weapon attributes

    public WeaponStats(int damage, float timeToAttack, float size)
    {
        this.damage = damage;   
        this.timeToAttack = timeToAttack;
        this.size = size;
    }
}
[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
}
