using UnityEngine;

namespace GameLogic
{
    public abstract class Elevator : MonoBehaviour
    {
        [Header("Elevator Settings")] 
        [SerializeField] private Rigidbody2D m_Rigidbody2D;
        [SerializeField] private float m_MovementSpeed; 
        [SerializeField] private float m_MaxPosition;
        [SerializeField] private float m_MinPosition;

        public int ButtonsPressed { get; set; }

        protected abstract void Move();

        protected void MoveUp()
        {
            if (transform.position.y < m_MaxPosition)
            {
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + (m_MovementSpeed * Time.fixedDeltaTime));
                if (newPosition.y > m_MaxPosition) // Small threshold to keep the max position
                {
                    newPosition.y = m_MaxPosition;
                }
                
                m_Rigidbody2D.MovePosition(newPosition);
            }
        }
    
        protected void MoveDown()
        {
            if (transform.position.y > m_MinPosition)
            {
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - (m_MovementSpeed * Time.fixedDeltaTime));
                if (newPosition.y < m_MinPosition) // Small threshold to keep the min position
                {
                    newPosition.y = m_MinPosition;
                }
                
                m_Rigidbody2D.MovePosition(newPosition);
            }
        }

        protected bool IsActivated()
        {
            return ButtonsPressed > 0;
        }
    }
}