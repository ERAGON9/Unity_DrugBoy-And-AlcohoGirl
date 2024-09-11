using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    public GameObject objectToMove;
    public float moveSpeed = 0.5f; 
    public float moveDistance = 2f;
    private bool isActivated = false;
    private Vector3 initialPosition;
    public Rigidbody2D Rigidbody2D => m_Rigidbody2D;
    private Vector3 m_StartPosition;


    // Start is called before the first frame update
    void Start()
    {
        m_StartPosition = transform.position;
        initialPosition = objectToMove.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated && objectToMove.transform.position.y < initialPosition.y + moveDistance)
        {
            objectToMove.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        if (!isActivated && objectToMove.transform.position.y > initialPosition.y)
        {
            objectToMove.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Button floor 1")
        {
            isActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Button floor 1")
        {
            isActivated = false;
        }
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
        transform.position = m_StartPosition;
    }
}
