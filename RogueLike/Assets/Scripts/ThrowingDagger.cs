using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDagger : WeaponBase
{
    [SerializeField] GameObject knifePrefab;


    public override void Attack()
    {
        GameObject thrownKnife = Instantiate(knifePrefab);
        thrownKnife.transform.position = transform.position;
        ThrowingDaggerProjectile projectile = thrownKnife.GetComponent<ThrowingDaggerProjectile>();

        projectile.throwingDagger = this;
        projectile.setDirection(playerMove.lastHorizontalVectorProjectiles, playerMove.lastVerticalVectorProjectiles);
        projectile.damage = weaponStats.damage;
        projectile.speed = projectile.speed * character.projectileSpeedMultiplier;
        projectile.size = weaponStats.size * character.areaMultiplier;
        projectile.transform.localScale = new Vector2(projectile.transform.localScale.x * transform.localScale.x, projectile.transform.localScale.y * transform.localScale.y);
    }
}
