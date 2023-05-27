using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour, iDamageable
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField] public float speed;
    private float reverseSpeed;
    private float originalSpeed;
    private float previousSpeed;

    private float timer;
    private float timer2 = 0.15f;
    Rigidbody2D rgbd2d;

    [SerializeField] float hp = 4;
    [SerializeField] int damage = 1;
    [SerializeField] Material whiteMat;
    Material originalMat;
    private SpriteRenderer sprite;
    private bool isSlowed = false;
    private bool tookDamage= false;
    private bool takingDamage= false;

    public bool TookDamage { get => tookDamage; set => tookDamage = value; }

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        originalMat = GetComponent<Renderer>().material;
        reverseSpeed = -1 * speed;
        originalSpeed = speed;
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;

        if (direction.x > 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

        if (takingDamage)
        {
            timer2 -= Time.deltaTime;
            GetComponent<Renderer>().material = whiteMat;
            speed = reverseSpeed;
            if (timer2 <= 0)
            {   
                GetComponent<Renderer>().material = originalMat;
                timer2 = 0.15f;
                takingDamage = false;
            }
        }
        else
            speed = originalSpeed;

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && isSlowed)
        {
            speed = previousSpeed;
            isSlowed = false;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (!takingDamage)
            takingDamage = true;
        else
            timer2 += 0.1f;

        if (hp<= 0)
        {
            Destroy(gameObject);
            GetComponent<DropOnDestroy>().CheckDrop();
        }
    }

    public void ApplySlow()
    {
        if (!isSlowed)
        {
            timer = 0.1f;
            isSlowed = true;
            previousSpeed = speed;
            speed = speed * 0.5f;
            
        }
        else
            timer += 0.1f;
    }

}