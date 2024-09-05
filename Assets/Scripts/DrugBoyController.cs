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
    [SerializeField][Range(0f, 1f)] private float  m_GroundFriction;

    [SerializeField] private BoxCollider2D m_GroundCheck;
    [SerializeField] private LayerMask m_GroundLayerMask;
    [SerializeField] private bool m_Grounded;
    
    private bool pressLeft = false;
    private bool pressRight = false;
    private bool pressUp = false;

    private int left = -1;
    private int right = 1;
    
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
    }
    
    private void FixedUpdate()
    {
        handleJumping();
        checkIfOnGround();
        applyFriction();
    }
    
    private void checkIfOnGround()
    {
        m_Grounded = Physics2D.OverlapAreaAll(m_GroundCheck.bounds.min, m_GroundCheck.bounds.max, m_GroundLayerMask).Length > 0;
    }
    
    private void applyFriction()
    {
        if (m_Grounded && !pressLeft && !pressRight && !pressUp)
        {
            m_DrugBoy.Rigidbody2D.velocity *= m_GroundFriction;
        }
    }
    
    private void checkIfOnGround3() // alternative to checkIfOnGround
    {
        m_Grounded = m_GroundCheck.IsTouchingLayers(m_GroundLayerMask);
    }

    private void checkIfOnGround2() // alternative to checkIfOnGround
    {
        Vector2 position = m_DrugBoy.Rigidbody2D.position;
        Vector2 direction = Vector2.down;
        float distance = 1f;
        LayerMask layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, layerMask);
        m_Grounded = hit.collider != null;
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
    }

    private void moveLeft()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;
        
        if (velocity.x >= 0) // Switch direction.
        {
            velocity = switchVelocityDirection(velocity);
            switchCharacterFaceDirection(left);
        }

        velocity.x -= m_MovementSpeed * Time.deltaTime;
        velocity = keepSpeedLimit(velocity);
        m_DrugBoy.Rigidbody2D.velocity = velocity;
    }

    private Vector2 switchVelocityDirection(Vector2 i_Velocity)
    {
        if (i_Velocity.x != 0)
        {
            i_Velocity.x *= -1;
        }

        return i_Velocity;
    }

    private void switchCharacterFaceDirection(int i_Direction)
    {
        Vector3 scale = m_DrugBoy.transform.localScale;
        scale.x = i_Direction;
        m_DrugBoy.transform.localScale = scale;
    }
    
    private Vector2 keepSpeedLimit(Vector2 i_Velocity)
    {
        if (i_Velocity.x < -m_MaxMovementSpeed) // Limit speed.
        {
            i_Velocity.x = -m_MaxMovementSpeed;
        }
        else if (i_Velocity.x > m_MaxMovementSpeed) // Limit speed.
        {
            i_Velocity.x = m_MaxMovementSpeed;
        }

        return i_Velocity;
    }
    
    private void movedRight()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;

        if (velocity.x <= 0) // Switch direction.
        {
            velocity = switchVelocityDirection(velocity);
            switchCharacterFaceDirection(right);
        }

        velocity.x += m_MovementSpeed * Time.deltaTime;
        velocity = keepSpeedLimit(velocity);
        m_DrugBoy.Rigidbody2D.velocity = velocity;
    }

    private void handleJumping()
    {
        if (pressUp && m_Grounded)
        {
            jump();
        }
    }

    private void jump()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;
        velocity.y = m_JumpForce;
        m_DrugBoy.Rigidbody2D.velocity = velocity;
    }
}
