using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDaggerProjectile : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    public float damage;
    public float size;
    [SerializeField] float decayTime = 10;

    public void setDirection(float dirx, float diry)
    {
        direction = new Vector3(dirx, diry);
        transform.right = direction;
    }

    bool hitDetected = false;
    // Update is called once per frame
    private void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
        //Debug.Log(transform.position);

        if (Time.frameCount % 6 == 0) //save time (check each 6 frames)
        {
            decayTime -= Time.deltaTime;
            Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, size);

            foreach (Collider2D collision in collisions)
            {
                iDamageable enemy = collision.GetComponent<iDamageable>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    PostDamage((int)damage, collision.transform.position);
                    hitDetected = true;
                    break;
                }

            }

            if (decayTime <= 0 || hitDetected)
            {
                Destroy(gameObject);
            }
        }
    }

    public void PostDamage(int damage, Vector3 worldPosition)
    {
        MessageSystem.instance.PostMessage(damage, worldPosition);
    }
}
