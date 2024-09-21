using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugBoy : MonoBehaviour
{
    public bool IsFinished { get; private set; } = false;
    
    
    private void OnCollisionEnter2D(Collision2D i_OtherCollioion)
    {
        handlePoolCollision(i_OtherCollioion);
    }
    
    private void handlePoolCollision(Collision2D i_OtherCollioion)
    {
        if (i_OtherCollioion.gameObject.CompareTag("WaterPool") || i_OtherCollioion.gameObject.CompareTag("AlcoholPool"))
        {
            MoveToInitialPosition();
        }
    }
    
    private void MoveToInitialPosition()
    {
        transform.position = DrugBoyController.Instance.InitialPosition;
    }
    
    private void OnTriggerEnter2D(Collider2D i_OtherCollider)
    {
        Debug.Log($"DrugBoy - OnTriggerEnter2D() - {i_OtherCollider.gameObject.name}"); // Added for debugging purposes
        HandleWeedBottleTrigger(i_OtherCollider);
        HandleDoorEnter(i_OtherCollider);
    }

    private void HandleWeedBottleTrigger(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("WeedBottle") && !i_OtherCollider.gameObject.GetComponent<Loot>().IsCollected)
        {
            i_OtherCollider.gameObject.GetComponent<Loot>().IsCollected = true;
            GameManager.Instance.AddPoints(10);
            Destroy(i_OtherCollider.gameObject);
        }
    }

    private void HandleDoorEnter(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("DrugBoyDoor"))
        {
            Debug.Log($"DrugBoy - HandleDoorEnter() - {i_OtherCollider.gameObject.name}"); // Added for debugging purposes
            IsFinished = true;
            GameManager.Instance.CheckLevelFinish();
        } 
    }
    
    private void OnTriggerExit2D(Collider2D i_OtherCollider)
    {
        HandleDoorExit(i_OtherCollider);
    }
    
    private void HandleDoorExit(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("DrugBoyDoor"))
        {
            Debug.Log($"DrugBoy - HandleDoorExit() - {i_OtherCollider.gameObject.name}"); // Added for debugging purposes
            IsFinished = false;
        } 
    }
}
