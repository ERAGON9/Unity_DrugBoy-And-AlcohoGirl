using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int m_MaxScore;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.MaxLevelScore = m_MaxScore;
    }
}
