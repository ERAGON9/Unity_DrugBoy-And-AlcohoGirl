using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcohoGirlController : ControllerSingleton<AlcohoGirlController>
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_LeftKey = KeyCode.A;
        m_RightKey = KeyCode.D;
        m_JumpKey = KeyCode.W;
    }
    
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
