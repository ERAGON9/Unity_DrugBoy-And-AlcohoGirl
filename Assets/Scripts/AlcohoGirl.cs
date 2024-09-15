using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcohoGirl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D i_Collision)
    {
        HandlePoolCollision(i_Collision);
    }

    private void HandlePoolCollision(Collision2D i_Collision)
    {
        if (i_Collision.gameObject.CompareTag("WaterPool") || i_Collision.gameObject.CompareTag("DrugPool"))
        {
            //TODO: Players failed.
            PlayerFailed();
        }
    }
    
    private void PlayerFailed()
    {
        Debug.Log("Failed");
        transform.position = AlcohoGirlController.Instance.InitialPosition;
    }
    
    private void OnTriggerEnter2D(Collider2D i_Collider)
    {
        HandleAlcoholBottleTrigger(i_Collider);
    }
    
    private void HandleAlcoholBottleTrigger(Collider2D i_Collider)
    {
        if (i_Collider.gameObject.CompareTag("AlcoholBottle"))
        {
            GameManager.instance.AddPoints(10);
            Destroy(i_Collider.gameObject);
        }
    }
}
