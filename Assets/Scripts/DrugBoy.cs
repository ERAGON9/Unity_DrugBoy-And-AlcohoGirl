using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugBoy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("WaterPool") || col.gameObject.CompareTag("AlcoholPool"))
        {
            PlayerFailed();
        }
    }
    
    private void PlayerFailed()
    {
        Debug.Log("Failed");
        transform.position = DrugBoyController.Instance.InitialPosition;
    }
}
