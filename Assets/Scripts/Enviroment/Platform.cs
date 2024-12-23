using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private TargetJoint2D targetJoint2D;

    [SerializeField] private float delayFall;
    private PlayerController playerController;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        targetJoint2D = GetComponent<TargetJoint2D>();
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.isGrounded = true;
            playerController.isJumping = false;
            Invoke("Falling", delayFall);    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        boxCollider2D.isTrigger = true;
        targetJoint2D.enabled = false;
    }
}
