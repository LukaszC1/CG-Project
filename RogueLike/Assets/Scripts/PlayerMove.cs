using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;

    [HideInInspector] public Vector3 movementVector;
    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;

    [SerializeField] float speed = 3f;

    Animate animate;
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<Animate>();
    }
    private void Start()
    {
        lastHorizontalVector = 1f; //initial value of the vector (for projectile weapons)
    }

    // Update is called once per frame
    void Update()
    {
     
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if(movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
           
        }
        else if (movementVector.y != 0)
            lastHorizontalVector = 0;


        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
           

        }
        else if (movementVector.x != 0)
            lastVerticalVector = 0;


        animate.horizontal = movementVector.x;

        movementVector *= speed;
        rgbd2d.velocity = movementVector;

    }

   
}
