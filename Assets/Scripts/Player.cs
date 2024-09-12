using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    
    public Rigidbody2D Rigidbody2D => m_Rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pool"))
        {
            PlayerFailed();
        }
    }
    void PlayerFailed()
    {
        Debug.Log("Failed");
        transform.position = DrugBoyController.Instance.InitialPosition;
    }
}
