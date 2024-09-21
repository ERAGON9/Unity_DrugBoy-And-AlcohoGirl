using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlcohoGirl : MonoBehaviour
{
    public bool IsFinished { get; private set; } = false;
    
    
    private void OnCollisionEnter2D(Collision2D i_OtherCollision)
    {
        HandlePoolCollision(i_OtherCollision);
    }

    private void HandlePoolCollision(Collision2D i_OtherCollision)
    {
        // We can do it a bit more fancy and add some logic of collisioning to the game manager
        // And then use it with the instance
        if (i_OtherCollision.gameObject.CompareTag("WaterPool") || i_OtherCollision.gameObject.CompareTag("DrugPool"))
        {
            MoveToInitialPosition();
        }
    }
    
    private void MoveToInitialPosition()
    {
        transform.position = AlcohoGirlController.Instance.InitialPosition;
    }
    
    private void OnTriggerEnter2D(Collider2D i_OtherCollider)
    {
        Debug.Log($"AlcohoGirl - OnTriggerEnter2D(). {i_OtherCollider.gameObject.name}"); // Added for debugging purposes
        HandleAlcoholBottleTrigger(i_OtherCollider);
        HandleDoorEnter(i_OtherCollider);
    }

    private void HandleAlcoholBottleTrigger(Collider2D i_OtherCollider)
    {
        // Same here, we can move some of the logic to the game manager
        if (i_OtherCollider.gameObject.CompareTag("AlcoholBottle") && !i_OtherCollider.gameObject.GetComponent<Loot>().IsCollected)
        {
            i_OtherCollider.gameObject.GetComponent<Loot>().IsCollected = true;
            GameManager.Instance.AddPoints(10);
            Destroy(i_OtherCollider.gameObject);
        }
    }
    
    private void HandleDoorEnter(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("AlcohoGirlDoor"))
        {
            Debug.Log($"AlcohoGirl - HandleDoorEnter() - {i_OtherCollider.gameObject.name}"); // Added for debugging purposes
            IsFinished = true;
            GameManager.Instance.CheckLevelFinish();
        } 
    }
    
    private void OnTriggerExit2D(Collider2D i_OtherCollider)
    {
        Debug.Log($"AlcohoGirl - OnTriggerExit2D() - {i_OtherCollider.gameObject.name}"); // Added for debugging purposes
        HandleDoorExit(i_OtherCollider);
    }
    
    private void HandleDoorExit(Collider2D i_OtherCollider)
    {
        if (i_OtherCollider.gameObject.CompareTag("AlcohoGirlDoor"))
        {
            Debug.Log($"AlcohoGirl - HandleDoorExit() - {i_OtherCollider.gameObject.name}"); // Added for debugging purposes
            IsFinished = false;
        } 
    }
}
