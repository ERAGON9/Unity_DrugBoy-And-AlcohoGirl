using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("Elevator Settings")] 
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private float m_MovementSpeed; 
    [SerializeField] private float m_MovementDistance;
    
    public bool IsActivated { get; set; } = false;
    
    private Vector3 m_InitialPosition;
    
    
    void Start()
    {
        m_InitialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        moveUp();
        moveDown();
    }

    private void moveUp()
    {
        if (IsActivated && transform.position.y < m_InitialPosition.y + m_MovementDistance)
        {
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + (m_MovementSpeed * Time.fixedDeltaTime));
            m_Rigidbody2D.MovePosition(newPosition);
        }
    }
    
    private void moveDown()
    {
        if (!IsActivated && transform.position.y > m_InitialPosition.y)
        {
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - (m_MovementSpeed * Time.fixedDeltaTime));
            m_Rigidbody2D.MovePosition(newPosition);
        }
    }
}
