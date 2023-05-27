using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDagger : WeaponBase
{
    [SerializeField] GameObject knifePrefab;
    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    public override void Attack()
    {
        GameObject thrownKnife = Instantiate(knifePrefab);
        thrownKnife.transform.position = transform.position;


        thrownKnife.GetComponent<ThrowingDaggerProjectile>().setDirection(playerMove.lastHorizontalVectorProjectiles, playerMove.lastVerticalVectorProjectiles);
    }
}
