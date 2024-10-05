using UnityEngine;

namespace GameLogic
{
    public class AlcohoGirlController : ControllerSingleton<AlcohoGirlController>
    {
        protected override void Start()
        {
            base.Start();
            m_LeftKey = KeyCode.A;
            m_RightKey = KeyCode.D;
            m_JumpKey = KeyCode.W;
        }
    }
}