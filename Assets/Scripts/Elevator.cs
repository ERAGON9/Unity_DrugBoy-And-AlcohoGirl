using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("Elevator Settings")]
    [SerializeField] private float m_MovementSpeed = 2f; 
    [SerializeField] private float m_MovementDistance = 4f;
    
    public bool IsActivated { get; set; } = false;
    
    private Vector3 m_InitialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        m_InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActivated && transform.position.y < m_InitialPosition.y + m_MovementDistance)
        {
            transform.Translate(Vector3.up * (m_MovementSpeed * Time.deltaTime));
        }

        if (!IsActivated && transform.position.y > m_InitialPosition.y)
        {
            transform.Translate(Vector3.down * (m_MovementSpeed * Time.deltaTime));
        }
    }
}
