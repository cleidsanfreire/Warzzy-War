using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;
    [SerializeField] private TypeObject typeObject;
    [SerializeField] private int points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.AddPoints(typeObject, points);
            anim = GetComponent<Animator>();
            anim.SetTrigger("isColected");
            Destroy(gameObject, 0.6f);
        }
    }
}
