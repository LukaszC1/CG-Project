using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] float magnetSize = 3;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, magnetSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            iPickUpObject e = colliders[i].GetComponent<iPickUpObject>();
            if (e != null)
            {
                e.setTargetDestination(transform);
            }
        }
    }
}
