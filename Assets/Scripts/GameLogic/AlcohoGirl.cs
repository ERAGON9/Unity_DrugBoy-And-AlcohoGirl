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
        HandleAlcoholBottleTrigger(i_OtherCollider);
        HandleDoorEnter(i_OtherCollider);
    }

    private void HandleAlcoholBottleTrigger(Collider2D i_OtherCollider)
    {
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
        if (i_OtherCollider.gameObject.CompareTag("AlcohoGirlDoor"))
        {
            IsFinished = false;
        } 
    }
}
