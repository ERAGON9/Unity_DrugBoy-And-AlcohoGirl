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
    
    private void OnCollisionEnter2D(Collision2D i_Collioion)
    {
        handlePoolCollision(i_Collioion);
    }
    
    private void handlePoolCollision(Collision2D i_Collision)
    {
        if (i_Collision.gameObject.CompareTag("WaterPool") || i_Collision.gameObject.CompareTag("AlcoholPool"))
        {
            //TODO: Players failed.
            PlayerFailed();
        }
    }
    
    private void PlayerFailed()
    {
        Debug.Log("Failed");
        transform.position = DrugBoyController.Instance.InitialPosition;
    }
    
    private void OnTriggerEnter2D(Collider2D i_Collider)
    {
        HandleWeedBottleTrigger(i_Collider);
    }
    
    private void HandleWeedBottleTrigger(Collider2D i_Collider)
    {
        if (i_Collider.gameObject.CompareTag("WeedBottle"))
        {
            GameManager.instance.AddPoints(10);
            Destroy(i_Collider.gameObject);
        }
    }
}
