using UnityEngine;

namespace GameLogic
{
    public class AlcohoGirl : MonoBehaviour
    {
        [Header("Audio")] 
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip m_LootClip;
        
        public bool IsFinished { get; private set; } = false;
    
    
        private void OnCollisionEnter2D(Collision2D i_OtherCollision)
        {
            handlePoolCollision(i_OtherCollision);
        }

        private void handlePoolCollision(Collision2D i_OtherCollision)
        {
            if (i_OtherCollision.gameObject.CompareTag("WaterPool") || i_OtherCollision.gameObject.CompareTag("DrugPool"))
            {
                GameManager.Instance.MoveAlcohoGirlToInitialPosition();
            }
        }
    
        private void OnTriggerEnter2D(Collider2D i_OtherCollider)
        {
            handleAlcoholBottleTrigger(i_OtherCollider);
            handleDoorEnter(i_OtherCollider);
        }

        private void handleAlcoholBottleTrigger(Collider2D i_OtherCollider)
        {
            if (i_OtherCollider.gameObject.CompareTag("AlcoholBottle") && !i_OtherCollider.gameObject.GetComponent<Loot>().IsCollected)
            {
                m_AudioSource.PlayOneShot(m_LootClip);
                i_OtherCollider.gameObject.GetComponent<Loot>().IsCollected = true;
                GameManager.Instance.AddPoints(10);
                Destroy(i_OtherCollider.gameObject);
            }
        }
    
        private void handleDoorEnter(Collider2D i_OtherCollider)
        {
            if (i_OtherCollider.gameObject.CompareTag("AlcohoGirlDoor"))
            {
                IsFinished = true;
                GameManager.Instance.CheckLevelFinish();
            } 
        }
    
        private void OnTriggerExit2D(Collider2D i_OtherCollider)
        {
            handleDoorExit(i_OtherCollider);
        }
    
        private void handleDoorExit(Collider2D i_OtherCollider)
        {
            if (i_OtherCollider.gameObject.CompareTag("AlcohoGirlDoor"))
            {
                IsFinished = false;
            } 
        }
    }
}