using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossItemPickUp : MonoBehaviour, iPickUpObject
{
    
    private float speed = 2.3f;
    private float speed2 = 3;
    Transform targetDestination;
    private float timer = 0.2f;



    public void OnPickUp(Character character)
    {
        //add the random upgrade to the character

        var upgrade = character.GetUpgrades(1)[0];

        while(upgrade.upgradeType.ToString() != UpgradeType.WeaponUpgrade.ToString() || upgrade.upgradeType.ToString() != UpgradeType.WeaponUpgrade.ToString())
        {
            upgrade = character.GetUpgrades(1)[0];
        }

        character.AcquiredUpgradesAdd(upgrade);
        character.UpgradesRemove(upgrade);
        character.UpgradeWeaponPickUp(upgrade);

        Destroy(gameObject);
    }

    private void Update()
    {
        if (targetDestination != null)
        {
            timer -= Time.deltaTime;
            if (timer >= 0)
            {
                Vector3 direction = (targetDestination.position - transform.position).normalized;
                transform.position -= speed2 * Time.deltaTime * direction.normalized;
                speed2 *= 0.99f;
            }
            else
            {
                Vector3 direction = (targetDestination.position - transform.position).normalized;
                transform.position += speed * Time.deltaTime * direction.normalized;
                speed *= 1.001f;
            }
        }
    }
    public void setTargetDestination(Transform destination)
    {
        targetDestination = destination;
    }
}
