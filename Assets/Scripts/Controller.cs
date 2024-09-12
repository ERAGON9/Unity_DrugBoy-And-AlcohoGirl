using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Controller : MonoBehaviour
{
    private const int k_FaceDirectionLeft = -1;
    private const int k_FaceDirectionRight = 1;
    
    [Header("Player Properties")]
    [SerializeField] private Player m_Player;
    [SerializeField] private Vector2 m_InitialPosition;
    [SerializeField] private float m_MovementSpeed;
    [SerializeField] private float m_MaxMovementSpeed;
    [SerializeField] private float m_JumpForce;
    
    [Header("Ground Properties")]
    [SerializeField][Range(0f, 1f)] private float  m_GroundFriction;
    [SerializeField] private BoxCollider2D m_GroundCheck;
    [SerializeField] private LayerMask m_GroundLayerMask;
    [SerializeField] private bool m_Grounded;
    
    [Header("Jump Improvement")]
    [SerializeField] private float m_JumpBufferTime = 0.1f;
    
    public Vector2 InitialPosition => m_InitialPosition;
    
    // Input Controls - Inherits need to set these values.
    protected KeyCode m_LeftKey;
    protected KeyCode m_RightKey;
    protected KeyCode m_JumpKey;
    
    private bool m_PressLeft = false;
    private bool m_PressRight = false;
    private bool m_PressJump = false;
    private float m_JumpBufferCounter = 0f;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_Player.Rigidbody2D.position = m_InitialPosition;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        checkInput();
        handleJumping();
    }

    protected virtual void FixedUpdate()
    {
        handleMovement();
        checkIfOnGround();
        applyFriction();
    }

    private void checkInput()
    {
        m_PressLeft = Input.GetKey(m_LeftKey);
        m_PressRight = Input.GetKey(m_RightKey);
        m_PressJump = Input.GetKeyDown(m_JumpKey);
    }
    
    private void handleJumping()
    {
        if (m_Grounded && (m_PressJump || m_JumpBufferCounter > 0f))
        {
            jump();
            m_JumpBufferCounter = 0f; // Reset jump buffer after jumping.
        }
        
        updateJumpBufferCounter();
    }

    private void jump()
    {
        m_Player.Rigidbody2D.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
    }
    
    private void updateJumpBufferCounter()
    {
        if (m_PressJump)
        {
            m_JumpBufferCounter = m_JumpBufferTime;
        }
        else if (!m_PressJump && m_JumpBufferCounter > 0f)
        {
            m_JumpBufferCounter -= Time.deltaTime;
        }
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
        Vector2 velocity = m_Player.Rigidbody2D.velocity;
        
        if (velocity.x >= 0) // Switch direction.
        {
            velocity = switchVelocityDirection(velocity);
        }

        velocity.x -= m_MovementSpeed * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, -m_MaxMovementSpeed, m_MaxMovementSpeed); // Speed limit.
        m_Player.Rigidbody2D.velocity = velocity;
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
        Vector3 scale = m_Player.transform.localScale;
        scale.x = i_Direction;
        m_Player.transform.localScale = scale;
    }
    
    private void movedRight()
    {
        Vector2 velocity = m_Player.Rigidbody2D.velocity;

        if (velocity.x <= 0) // Switch direction.
        {
            velocity = switchVelocityDirection(velocity);
        }

        velocity.x += m_MovementSpeed * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, -m_MaxMovementSpeed, m_MaxMovementSpeed); // Speed limit.
        m_Player.Rigidbody2D.velocity = velocity;
        updateCharacterFaceDirection(k_FaceDirectionRight);
    }
        
    private void checkIfOnGround()
    {
        m_Grounded = Physics2D.OverlapAreaAll(m_GroundCheck.bounds.min, m_GroundCheck.bounds.max,
                                                    m_GroundLayerMask).Length > 0;
    }
    
    private void applyFriction()
    {
        if (m_Grounded && !m_PressLeft && !m_PressRight && m_Player.Rigidbody2D.velocity.y <= 0)
        {
            Vector2 velocity = m_Player.Rigidbody2D.velocity;
            velocity.x *= m_GroundFriction;
            if (Mathf.Abs(velocity.x) < 0.01f) // Small threshold to avoid floating-point precision issues
            {
                velocity.x = 0;
            }

            m_Player.Rigidbody2D.velocity = velocity;
        }
    }
}
