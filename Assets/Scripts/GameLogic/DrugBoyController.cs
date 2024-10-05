using UnityEngine;

namespace GameLogic
{
    public class DrugBoyController : ControllerSingleton<DrugBoyController>
    {
        protected override void Start()
        {
            base.Start();
            m_LeftKey = KeyCode.LeftArrow;
            m_RightKey = KeyCode.RightArrow;
            m_JumpKey = KeyCode.UpArrow;
        }
    }
}