using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private TypeObject typeObject;
    [SerializeField] private int pointLife;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.AddPoints(typeObject, pointLife);
            Destroy(gameObject, 0.3f);
        }

    }
}
