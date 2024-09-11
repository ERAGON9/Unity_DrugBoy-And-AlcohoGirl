using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    
    [SerializeField] private GameObject m_Elevator;
    [SerializeField] private float m_ElevatorMoveSpeed; 
    [SerializeField] private float m_ElevatorMoveDistance;
    
    public Rigidbody2D Rigidbody2D => m_Rigidbody2D;

    private bool m_IsButtonActivated = false;
    private Vector3 m_ElevatorInitialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        m_ElevatorInitialPosition = m_Elevator.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsButtonActivated && m_Elevator.transform.position.y < m_ElevatorInitialPosition.y + m_ElevatorMoveDistance)
        {
            m_Elevator.transform.Translate(Vector3.up * (m_ElevatorMoveSpeed * Time.deltaTime));
        }

        if (!m_IsButtonActivated && m_Elevator.transform.position.y > m_ElevatorInitialPosition.y)
        {
            m_Elevator.transform.Translate(Vector3.down * (m_ElevatorMoveSpeed * Time.deltaTime));
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            m_IsButtonActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            m_IsButtonActivated = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pool"))
        {
            PlayerFailed();
        }
    }
    void PlayerFailed()
    {
        Debug.Log("Failed");
        transform.position = DrugBoyController.Instance.InitialPosition;
    }
}
