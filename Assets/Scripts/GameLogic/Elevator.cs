using UnityEngine;

namespace GameLogic
{
    public class Elevator : MonoBehaviour
    {
        [Header("Elevator Settings")] 
        [SerializeField] private Rigidbody2D m_Rigidbody2D;
        [SerializeField] private float m_MovementSpeed; 
        [SerializeField] private float m_MovementDistance;
    
        public int ButtonsPressed = 0;

        private Vector3 m_InitialPosition;
        private Vector3 m_MaxedPosition;
    
        void Start()
        {
            m_InitialPosition = transform.position;
            m_MaxedPosition = new Vector3(m_InitialPosition.x, m_InitialPosition.y + m_MovementDistance, m_InitialPosition.z);
        }

        private void FixedUpdate()
        {
            moveUp();
            moveDown();
        }

        private void moveUp()
        {
            if (isActivated() && transform.position.y < m_MaxedPosition.y)
            {
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + (m_MovementSpeed * Time.fixedDeltaTime));
                m_Rigidbody2D.MovePosition(newPosition);
            }
        }
    
        private void moveDown()
        {
            if (!isActivated() && transform.position.y > m_InitialPosition.y)
            {
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - (m_MovementSpeed * Time.fixedDeltaTime));
                m_Rigidbody2D.MovePosition(newPosition);
            }
        }

        private bool isActivated()
        {
            return ButtonsPressed > 0;
        }
    }
}
