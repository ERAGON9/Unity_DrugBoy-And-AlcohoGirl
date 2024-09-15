using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Elevator m_ConnectedElevator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D i_Collider)
    {
        handlePlayerTriggerEnter(i_Collider);
    }
    
    private void handlePlayerTriggerEnter(Collider2D i_Collider)
    {
        if (i_Collider.gameObject.CompareTag("Player"))
        {
            m_ConnectedElevator.IsActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        handlePlayerTriggerExit(other);

    }

    private void handlePlayerTriggerExit(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_ConnectedElevator.IsActivated = false;
        }
    }
}
