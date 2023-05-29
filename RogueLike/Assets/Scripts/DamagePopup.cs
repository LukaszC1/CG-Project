using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [SerializeField ]float timeToLive = 1f;
    float ttl = 1f;
    TMPro.TextMeshPro textMeshPro;

    public bool isActive = false;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        ttl = timeToLive;
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            ttl -= Time.deltaTime;

            if (ttl > 0.5f)
            {
                transform.localScale = new Vector3(transform.localScale.x * 1.002f, transform.localScale.y * 1.002f, transform.localScale.z);
            }
            else if (ttl > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * 0.999f, transform.localScale.y * 0.999f, transform.localScale.z);
                textMeshPro.alpha *= 0.988f;
            }
            else if (ttl < 0)
            {
                gameObject.SetActive(false);
            }
        }

    }

}
