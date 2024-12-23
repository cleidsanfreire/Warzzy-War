using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive : MonoBehaviour
{
    [SerializeField] GameObject fireObject;
    private bool isTrigger;

    private void Update()
    {
        
        if (isTrigger && Input.GetKeyDown(KeyCode.E))
        {
            FireController fireController = fireObject.GetComponent<FireController>();
            if (fireController != null)
            {
                fireController.isOn = !fireController.isOn;
            }
        }  
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
            PlayerController playerController = collision.GetComponent<PlayerController>();
            playerController.isGrounded = true;
            playerController.isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }
}
