using UnityEngine;

namespace GameLogic
{
    public class DrugBoySpawnLocation : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.3f);
        }
    }
}
