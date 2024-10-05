using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private int m_MaxScore;
    
    
    void Start()
    {
        GameManager.Instance.MaxLevelScore = m_MaxScore;
    }
}