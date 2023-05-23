using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDagger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timeToAttack;
    float timer;
    [SerializeField] GameObject knifePrefab;
    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    // Update is called once per frame
    private void Update()
    {
        if(timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }
        timer = 0;
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        GameObject thrownKnife = Instantiate(knifePrefab);
        thrownKnife.transform.position = transform.position;
        thrownKnife.GetComponent<ThrowingDaggerProjectile>().setDirection(playerMove.lastHorizontalVector, 0f);
    }
}
