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
    
    [Header("Ground Properties")]
    [SerializeField][Range(0f, 1f)] private float  m_GroundFriction;
    [SerializeField] private BoxCollider2D m_GroundCheck;
    [SerializeField] private LayerMask m_GroundLayerMask;
    [SerializeField] private bool m_Grounded;
    
    private bool m_PressLeft = false;
    private bool m_PressRight = false;
    private bool m_PressUp = false;

    private const int k_FaceDirectionLeft = -1;
    private const int k_FaceDirectionRight = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        m_DrugBoy.Rigidbody2D.position = m_InitialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }
    
    private void FixedUpdate()
    {
        handleMovement();
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
        if (m_Grounded && !m_PressLeft && !m_PressRight && !m_PressUp)
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
        m_PressLeft = Input.GetKey(KeyCode.LeftArrow);
        m_PressRight = Input.GetKey(KeyCode.RightArrow);
        m_PressUp = Input.GetKey(KeyCode.UpArrow);
    }

    private void handleMovement()
    {
        if (m_PressLeft)
        {
            moveLeft();
        }
        else if (m_PressRight)
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
        }

        velocity.x -= m_MovementSpeed * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, -m_MaxMovementSpeed, m_MaxMovementSpeed); // Limit speed.
        m_DrugBoy.Rigidbody2D.velocity = velocity;
        updateCharacterFaceDirection(k_FaceDirectionLeft);
    }

    private Vector2 switchVelocityDirection(Vector2 i_Velocity)
    {
        if (i_Velocity.x != 0)
        {
            i_Velocity.x *= -1;
        }

        return i_Velocity;
    }

    private void updateCharacterFaceDirection(int i_Direction)
    {
        Vector3 scale = m_DrugBoy.transform.localScale;
        scale.x = i_Direction;
        m_DrugBoy.transform.localScale = scale;
    }
    
    private void movedRight()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;

        if (velocity.x <= 0) // Switch direction.
        {
            velocity = switchVelocityDirection(velocity);
        }

        velocity.x += m_MovementSpeed * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, -m_MaxMovementSpeed, m_MaxMovementSpeed); // Limit speed.
        m_DrugBoy.Rigidbody2D.velocity = velocity;
        updateCharacterFaceDirection(k_FaceDirectionRight);
    }

    private void handleJumping()
    {
        if (m_PressUp && m_Grounded)
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
