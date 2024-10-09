using UnityEngine;

namespace GameLogic
{
    public class AlcohoGirlSpawnLocation : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(transform.position, 0.3f);
        }
    }
}
