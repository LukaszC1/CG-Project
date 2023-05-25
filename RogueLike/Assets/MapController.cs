using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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

    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckChunks();
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
            }

        }
    }

    void ChunkSpawner()
    {
        int rand = Random.Range(0, terrainChunk.Count);
        Instantiate(terrainChunk[rand], noTerrain, Quaternion.identity);
    }
}


