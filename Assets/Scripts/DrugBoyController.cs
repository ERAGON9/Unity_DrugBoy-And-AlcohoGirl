using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugBoyController : ControllerSingleton<DrugBoyController>
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_LeftKey = KeyCode.LeftArrow;
        m_RightKey = KeyCode.RightArrow;
        m_JumpKey = KeyCode.UpArrow;
    }
    
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
