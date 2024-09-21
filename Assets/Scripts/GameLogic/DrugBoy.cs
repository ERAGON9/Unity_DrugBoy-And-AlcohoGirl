using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugBoy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D i_Collioion)
    {
        handlePoolCollision(i_Collioion);
    }
    
    private void handlePoolCollision(Collision2D i_Collision)
    {
        if (i_Collision.gameObject.CompareTag("WaterPool") || i_Collision.gameObject.CompareTag("AlcoholPool"))
        {
            MoveToInitialPosition();
        }
    }
    
    private void MoveToInitialPosition()
    {
        transform.position = DrugBoyController.Instance.InitialPosition;
    }
    
    private void OnTriggerEnter2D(Collider2D i_Collider)
    {
        Debug.Log($"DrugBoy - OnTriggerEnter2D(). {i_Collider.gameObject.name}"); // Added for debugging purposes
        HandleWeedBottleTrigger(i_Collider);
        HandleDoorEnter(i_Collider);
    }

    private void OnTriggerExit2D(Collider2D i_Collider)
    {
        HandleDoorExit(i_Collider);
    }

    private void HandleWeedBottleTrigger(Collider2D i_Collider)
    {
        if (i_Collider.gameObject.CompareTag("WeedBottle") && !i_Collider.gameObject.GetComponent<Loot>().IsCollected)
        {
            i_Collider.gameObject.GetComponent<Loot>().IsCollected = true;
            GameManager.Instance.AddPoints(10);
            Destroy(i_Collider.gameObject);
        }
    }

    private void HandleDoorEnter(Collider2D i_Collider)
    {
        if (i_Collider.gameObject.CompareTag("DrugBoyDoor"))
        {
            Debug.Log("DrugBoy - HandleDoorEnter()."); // Added for debugging purposes
            GameManager.Instance.DrugBoyInFinish = true;
            GameManager.Instance.CheckLevelFinish();
        } 
    }
    
    private void HandleDoorExit(Collider2D i_Collider)
    {
        if (i_Collider.gameObject.CompareTag("DrugBoyDoor"))
        {
            Debug.Log("DrugBoy - HandleDoorExit()."); // Added for debugging purposes
            GameManager.Instance.DrugBoyInFinish = false;
        } 
    }
}
