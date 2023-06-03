using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public List<GameObject> terrainChunk;
    public GameObject currentChunk;
    public GameObject player;
    public float radius;
    Vector3 noTerrain;
    public LayerMask terrainMask;
    PlayerMove movement;

    [Header("Optimization")]
    public List<GameObject> spawnedChunk;
    public GameObject latest;
    public float maxDistance; //> chunk size
    float dist;
    float cooldown;
    public float cooldownTime;



    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckChunks();
        optimizer();
    }


    void CheckChunks()
    {
        if (!currentChunk)
        {
            return;
        }

        if (movement.movementVector.x > 0 && movement.movementVector.y == 0) //right side
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, radius, terrainMask))
            {
                noTerrain = currentChunk.transform.Find("Right").position;
                ChunkSpawner();
            }

        }

       else if (movement.movementVector.x < 0 && movement.movementVector.y == 0) //left side
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, radius, terrainMask))
            {
                noTerrain = currentChunk.transform.Find("Left").position;
                ChunkSpawner();
            }

        }

        else if (movement.movementVector.x == 0 && movement.movementVector.y > 0) //upper side
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, radius, terrainMask))
            {
                noTerrain = currentChunk.transform.Find("Up").position;
                ChunkSpawner();
            }

        }

        else if (movement.movementVector.x == 0 && movement.movementVector.y < 0) //lower side
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, radius, terrainMask))
            {
                noTerrain = currentChunk.transform.Find("Down").position;
                ChunkSpawner();
            }

        }

        else if (movement.movementVector.x > 0 && movement.movementVector.y > 0) //R up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position, radius, terrainMask))
            {
                noTerrain = currentChunk.transform.Find("Right Up").position;
                ChunkSpawner();
            }

        }

        else if (movement.movementVector.x > 0 && movement.movementVector.y < 0) //R down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position, radius, terrainMask))
            {
                noTerrain = currentChunk.transform.Find("Right Down").position;
                ChunkSpawner();
            }

        }

        else if (movement.movementVector.x < 0 && movement.movementVector.y > 0) //L up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, radius, terrainMask))
            {
                noTerrain = currentChunk.transform.Find("Left Up").position;
                ChunkSpawner();
            }

        }

        else if (movement.movementVector.x < 0 && movement.movementVector.y < 0) //L down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, radius, terrainMask))
            {
                noTerrain = currentChunk.transform.Find("Left Down").position;
                ChunkSpawner();
                spawnedChunk.Add(latest);
            }

        }
    }

    void ChunkSpawner()
    {
        int rand = UnityEngine.Random.Range(0, terrainChunk.Count);
        latest = Instantiate(terrainChunk[rand], noTerrain, Quaternion.identity);
        spawnedChunk.Add(latest);
    }

    void optimizer()
    {


        cooldown -= Time.deltaTime;

        if (cooldown < 0f)
        {
            cooldown = cooldownTime;
        }
        else
        {
            return;
        }


        foreach (GameObject chunk in spawnedChunk)
        {

            dist = Vector3.Distance(player.transform.position, chunk.transform.position);  
            if (dist > maxDistance) 
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}


