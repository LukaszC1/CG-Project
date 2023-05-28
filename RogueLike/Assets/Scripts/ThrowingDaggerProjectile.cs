using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDaggerProjectile : WeaponBase
{
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 5;
    [SerializeField] float decayTime = 10;

    public void setDirection(float dirx, float diry)
    {
        direction = new Vector3(dirx, diry);
        transform.right = direction;
    }

    bool hitDetected = false;
    // Update is called once per frame
    new private void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
        //Debug.Log(transform.position);

        if (Time.frameCount % 6 == 0) //save time (check each 6 frames)
        {
            decayTime -= Time.deltaTime;
            Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, 0.5f);

            foreach (Collider2D collision in collisions)
            {
                iDamageable enemy = collision.GetComponent<iDamageable>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    PostMessage(damage, collision.transform.position);
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

    public override void Attack()
    {
        //empty for this weapon since it uses slow mechanic in update
    }
}
