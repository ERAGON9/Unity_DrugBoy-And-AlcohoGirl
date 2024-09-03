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
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_DrugBoy.Rigidbody2D.position = m_InitialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleJumping();
    }
    
    private void handleMovement2()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_DrugBoy.Rigidbody2D.velocity = new Vector2(-1 * m_MovementSpeed * Time.deltaTime ,m_DrugBoy.Rigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_DrugBoy.Rigidbody2D.velocity = new Vector2(m_MovementSpeed * Time.deltaTime ,m_DrugBoy.Rigidbody2D.velocity.y);
        }
    }
    
    private void handleJumping2()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_DrugBoy.Rigidbody2D.velocity = new Vector2(m_DrugBoy.Rigidbody2D.velocity.x, m_JumpForce);
        }
    }
    
    private void handleMovement()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (velocity.x > 0) // Switch direction.
            {
                velocity.x *= -1;
            }
            
            velocity.x += -1 * (m_MovementSpeed * Time.deltaTime);
            if (velocity.x < -1 * m_MaxMovementSpeed) // Limit speed.
            {
                velocity.x = -1 * m_MaxMovementSpeed;
            }

            m_DrugBoy.Rigidbody2D.velocity = velocity;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
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
        // else
        // {
        //     velocity.x /= 2;
        //     m_DrugBoy.Rigidbody2D.velocity = velocity;
        // }
    }
    
    private void handleJumping()
    {
        Vector2 velocity = m_DrugBoy.Rigidbody2D.velocity;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y += m_JumpForce * Time.deltaTime;
            m_DrugBoy.Rigidbody2D.velocity = velocity;
        }
    }
}
