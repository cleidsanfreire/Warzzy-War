using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollect : MonoBehaviour
{
    private PlayerController playerController;
    private Animator anim;
    public TypeObject typeObject;
    public int points;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController = collision.GetComponent<PlayerController>();
            anim = GetComponent<Animator>();
            playerController.AddPoints(typeObject, points);
            anim.SetTrigger("isColected");
            Destroy(gameObject, 0.5f);

        }
    }
}
