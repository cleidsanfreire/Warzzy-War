using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private PlayerController playerController;
    private GameObject active;

    private Animator anim;

    private bool _isOn;

    public bool isOn { get => _isOn; set => _isOn = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("isOn", isOn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                    TakeDamage();
            }
        }
        
    }
    void TakeDamage()
    {
        playerController.CurrentlifePlayer--;
    }
}
