using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugBoyController : Singleton<DrugBoyController>
{
    [Header("DrugBoy Properties")]
    [SerializeField] private Player m_DrugBoy;
    [SerializeField] private Vector2 m_InitialPosition;
    [SerializeField] private float m_MovementSpeed;
    [SerializeField] private float m_MaxMovementSpeed;
    [SerializeField] private float m_JumpForce;
    [SerializeField][Range(0f, 1f)] private float  m_MovementDrag;

    private bool pressLeft = false;
    private bool pressRight = false;
    private bool pressUp = false;
    
    // Start is called before the first frame update
    void Start()
    {
        m_DrugBoy.Rigidbody2D.position = m_InitialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        handleMovement();
        handleJumping();
    }
    
    private void FixedUpdate()
    {
        //Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;
        //velocity.x *= m_Drag;
        //m_DrugBoy.Rigidbody2D.velocity = velocity;
    }
    
    private void getInput()
    {
        pressLeft = Input.GetKey(KeyCode.LeftArrow);
        pressRight = Input.GetKey(KeyCode.RightArrow);
        pressUp = Input.GetKey(KeyCode.UpArrow);
    }

    private void handleMovement()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;

        if (pressLeft)
        {
            moveLeft();
        }
        else if (pressRight)
        {
            movedRight();
        }
        else
        {
            velocity.x *= m_MovementDrag;
            m_DrugBoy.Rigidbody2D.velocity = velocity;
        }
    }

    private void moveLeft()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;
        
        if (velocity.x > 0) // Switch direction.
        {
            velocity.x *= -1;
        }

        velocity.x -= m_MovementSpeed * Time.deltaTime;
        if (velocity.x < -m_MaxMovementSpeed) // Limit speed.
        {
            velocity.x = -m_MaxMovementSpeed;
        }

        m_DrugBoy.Rigidbody2D.velocity = velocity;
    }

    private void movedRight()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;

        if (velocity.x < 0) // Switch direction.
        {
            velocity.x *= -1;
        }

        velocity.x += m_MovementSpeed * Time.deltaTime;
        if (velocity.x > m_MaxMovementSpeed) // Limit speed.
        {
            velocity.x = m_MaxMovementSpeed;
        }

        m_DrugBoy.Rigidbody2D.velocity = velocity;
    }

    private void handleJumping()
    {
        if (pressUp)
        {
            jump();
        }
    }

    private void jump()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;
        velocity.y += m_JumpForce * Time.deltaTime;
        m_DrugBoy.Rigidbody2D.velocity = velocity;
    }
}
