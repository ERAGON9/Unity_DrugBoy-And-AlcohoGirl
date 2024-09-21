using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBridge : MonoBehaviour
{
    [SerializeField] private Bridge m_ConnectedBridge;
    
    
    private void OnTriggerEnter2D(Collider2D i_OtherCollider)
    {
        HandlePlayerTriggerEnter(i_OtherCollider);
    }
    
    private void HandlePlayerTriggerEnter(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("Player"))
        {
            m_ConnectedBridge.IsActivated = true;
            Destroy(this.gameObject);
        }
    }
}
