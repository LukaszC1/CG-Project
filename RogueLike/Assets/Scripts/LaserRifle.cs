using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRifle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timeToAttack;
    float timer;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] EnemiesManager enemiesManager;

    

    private void Awake()
    {
    
    }


    // Update is called once per frame
    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }
        timer = 0;
        SpawnKnife();
    }

    private void SpawnKnife()
    {

        if (enemiesManager.enemyList.Count == 0) { return; }
        GameObject thrownKnife = Instantiate(laserPrefab);
        Vector3 currentPosition = transform.position;
        thrownKnife.transform.position = currentPosition;

        Transform closestEnemy = GetClosestEnemy(enemiesManager.enemyList, currentPosition);
        Vector3 throwDirection = closestEnemy.position - currentPosition;

        thrownKnife.GetComponent<ThrowingDaggerProjectile>().setDirection(throwDirection.x, throwDirection.y);
    }

    Transform GetClosestEnemy(List<GameObject> enemies, Vector3 currentPosition)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }
        return bestTarget;
    }

}
