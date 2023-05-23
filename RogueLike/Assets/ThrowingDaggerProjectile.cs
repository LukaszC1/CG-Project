using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDaggerProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] int damage = 5;

    public void setDirection(float dirX, float dirY)
    {
        direction = new Vector3(dirX, dirY);

        if (dirX < 0) 
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    bool hitDetected = false;
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Time.frameCount % 6 == 0) //save time (check each 6 frames)
        {
            Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, 0.5f);

            foreach (Collider2D collision in collisions)
            {
                Enemy enemy = collision.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }

            }
            if (hitDetected)
            {
                Destroy(gameObject);
            }
        }
    }
}
