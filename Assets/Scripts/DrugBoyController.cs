using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugBoyController : Singleton<DrugBoyController>
{
    [Header("DrugBoy Properties")]
    [SerializeField] private Player m_DrugBoy;
    [SerializeField] private Vector2 m_InitialPosition;
    [SerializeField] private float m_MovementSpeed;
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
    }

    private void handleMovement()
    {
        var velocity = m_DrugBoy.Rigidbody2D.velocity;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (velocity.x > 0)
            {
                velocity.x = 0;
            }
            
            velocity.x += -1 * (m_MovementSpeed * Time.deltaTime);
            m_DrugBoy.Rigidbody2D.velocity = velocity;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (velocity.x < 0)
            {
                velocity.x = 0;
            }
            
            velocity.x += m_MovementSpeed * Time.deltaTime;
            m_DrugBoy.Rigidbody2D.velocity = velocity;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y += m_JumpForce * Time.deltaTime;
            m_DrugBoy.Rigidbody2D.velocity = velocity;
        }
    }
}
