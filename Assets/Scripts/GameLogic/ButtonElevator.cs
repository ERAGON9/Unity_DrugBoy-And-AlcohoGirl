using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElevator : MonoBehaviour
{
    [SerializeField] private Elevator m_ConnectedElevator;
    
    
    private void OnTriggerEnter2D(Collider2D i_OtherCollider)
    {
        HandlePlayerTriggerEnter(i_OtherCollider);
    }
    
    private void HandlePlayerTriggerEnter(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("Player"))
        {
            m_ConnectedElevator.ButtonsPressed++;
        }
    }

    private void OnTriggerExit2D(Collider2D i_OtherCollider)
    {
        HandlePlayerTriggerExit(i_OtherCollider);
    }

    private void HandlePlayerTriggerExit(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("Player"))
        {
            m_ConnectedElevator.ButtonsPressed--;
        }
    }
}
