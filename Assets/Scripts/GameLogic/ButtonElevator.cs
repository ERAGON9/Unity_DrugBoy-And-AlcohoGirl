using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElevator : MonoBehaviour
{
    [Header("Button Elevator Settings")]
    [SerializeField] private Elevator m_ConnectedElevator;
    
    
    private void OnTriggerEnter2D(Collider2D i_OtherCollider)
    {
        handlePlayerTriggerEnter(i_OtherCollider);
    }
    
    private void handlePlayerTriggerEnter(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("Player"))
        {
            m_ConnectedElevator.ButtonsPressed++;
        }
    }

    private void OnTriggerExit2D(Collider2D i_OtherCollider)
    {
        handlePlayerTriggerExit(i_OtherCollider);
    }

    private void handlePlayerTriggerExit(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("Player"))
        {
            m_ConnectedElevator.ButtonsPressed--;
        }
    }
}