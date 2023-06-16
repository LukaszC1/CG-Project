using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int xpGemAmount;
    public float xpBank;
    public Transform playerTransform;

    [SerializeField] GameObject xpBankGemPrefab;
    GameObject xpBankGem;

    private void Awake()
    {
        Instance = this;
        xpBankGem = Instantiate(xpBankGemPrefab);
        xpBankGem.SetActive(false);
    }

    private void Update()
    {
        if (xpBank > 100 && !xpBankGem.activeSelf)
        {
            xpBankGem.SetActive(true);
            Vector3 position = GenerateRandomPosition();
            while (CheckForCollision(position))
                position = GenerateRandomPosition();
            xpBankGem.transform.position = position;   
        }

    }

    public Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;

        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-23, 8);
            position.y = 8 * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-23, 8);
            position.x = 23 * f;
        }
        position.x += playerTransform.position.x;
        position.y += playerTransform.position.y;
        position.z = 0;

        return position;
    }

    private bool CheckForCollision(Vector3 position)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(position, 0.1f);
        foreach (Collider2D collision in collisions)
        {
            if (collision.attachedRigidbody != null)
            {
                return true;
            }
        }
        return false;
    }
}
