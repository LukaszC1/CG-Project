using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public static MessageSystem instance;

    private void Awake()
    {
        instance = this; 
    }

    int objectCount = 10;
    int count = 0;

    private void Start()
    {
        messagePool = new List<TextMeshPro>();

            for(int i =0;i < objectCount; i++)
        {
            fillList();
        }
    }

    [SerializeField] GameObject damagePopup;
    List<TMPro.TextMeshPro> messagePool;

    public void PostMessage (string message, Vector3 position)
    {
        messagePool[count].gameObject.SetActive (true);
        messagePool[count].transform.position = position;
        messagePool[count].text = message;
        count += 1;

        if(count >= objectCount)
        {
            count = 0;
        }
    }

    public void fillList()
    {
        GameObject go = Instantiate(damagePopup, transform);
        messagePool.Add(go.GetComponent<TMPro.TextMeshPro>());
        go.SetActive(false);
    }
}
