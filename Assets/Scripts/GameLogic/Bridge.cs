using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [Header("Bridge Settings")] 
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private float m_RotateSpeed; 
    
    public bool IsActivated { get; set; } = false;
    
    
    private void FixedUpdate()
    {
        rotate();
    }

    private void rotate()
    {
        if (IsActivated && m_Rigidbody2D.rotation > 0)
        {
            float newRotation = m_Rigidbody2D.rotation - (m_RotateSpeed * Time.fixedDeltaTime);
            if (newRotation < 0.1f) // Small threshold to reset the rotation to 0
            {
                newRotation = 0;
            }
            
            m_Rigidbody2D.MoveRotation(newRotation);
        }
    }
}