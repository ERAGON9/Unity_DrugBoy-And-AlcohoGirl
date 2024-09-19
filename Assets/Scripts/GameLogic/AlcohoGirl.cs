using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlcohoGirl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D i_Collision)
    {
        HandlePoolCollision(i_Collision);
    }

    private void HandlePoolCollision(Collision2D i_Collision)
    {
        if (i_Collision.gameObject.CompareTag("WaterPool") || i_Collision.gameObject.CompareTag("DrugPool"))
        {
            MoveToInitialPosition();
        }
    }
    
    private void MoveToInitialPosition()
    {
        transform.position = AlcohoGirlController.Instance.InitialPosition;
    }
    
    private void OnTriggerEnter2D(Collider2D i_Collider)
    {
        HandleAlcoholBottleTrigger(i_Collider);
        HandleDoorEnter(i_Collider);
    }

    
    private void OnTriggerExit2D(Collider2D i_Collider)
    {
        HandleDoorExit(i_Collider);
    }

    private void HandleAlcoholBottleTrigger(Collider2D i_Collider)
    {
        if (i_Collider.gameObject.CompareTag("AlcoholBottle") && !i_Collider.gameObject.GetComponent<Loot>().IsCollected)
        {
            i_Collider.gameObject.GetComponent<Loot>().IsCollected = true;
            GameManager.Instance.AddPoints(10);
            Destroy(i_Collider.gameObject);
        }
    }
    
    private void HandleDoorEnter(Collider2D i_Collider)
    {
        if (i_Collider.gameObject.CompareTag("AlcohoGirlDoor"))
        {
            GameManager.Instance.AlcohoGirlInFinish = true;
            GameManager.Instance.CheckWin();
        } 
    }
    
    private void HandleDoorExit(Collider2D i_Collider)
    {
        if (i_Collider.gameObject.CompareTag("AlcohoGirlDoor"))
        {
            GameManager.Instance.AlcohoGirlInFinish = false;
        } 
    }
}
