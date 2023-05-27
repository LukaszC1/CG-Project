using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectContainer;
    [SerializeField] WeaponData startingWeapon;
    [SerializeField] public EnemiesManager enemiesManager;

    List<WeaponBase> weapons;

    private void Awake()
    {
        weapons = new List<WeaponBase>();
    }
    private void Start()
    {
        AddWeapon(startingWeapon);
    }
    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectContainer);
        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);

        Character character = GetComponent<Character>();

        if(character != null)
        {
            character.AddUpgradesIntoList(weaponData.upgrades);
        }
    }

    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
