using UnityEngine;

namespace GameLogic
{
    public class ButtonBridge : MonoBehaviour
    {
        [Header("Button Bridge Settings")]
        [SerializeField] private Bridge m_ConnectedBridge;
    
    
        private void OnTriggerEnter2D(Collider2D i_OtherCollider)
        {
            handlePlayerTriggerEnter(i_OtherCollider);
        }
    
        private void handlePlayerTriggerEnter(Collider2D i_OtherCollider)
        {
            if (i_OtherCollider.gameObject.CompareTag("Player"))
            {
                m_ConnectedBridge.IsActivated = true;
                Destroy(this.gameObject);
            }
        }
    }
}
