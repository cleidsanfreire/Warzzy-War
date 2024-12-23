using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBroken : MonoBehaviour
{
    private PlayerController playerController;
    private Animator anim;

    [Header("Box Empety")]
    [SerializeField] private int _lifeBox;
    [SerializeField] private int _currentlifeBox;

    public int lifeBox { get => _lifeBox; set => _lifeBox = value; }
    public int currentlifeBox { get => _currentlifeBox; set => _currentlifeBox = value; }

    private void Start()
    {
        _currentlifeBox = _lifeBox;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null && playerController.isJumping)
            {
                TakeDamage();
                Debug.Log("oaaaa");
            }
            playerController.isGrounded = true;
            playerController.isJumping = false;
            Debug.Log("o");
        }
    }

    void TakeDamage()
    {
        anim = GetComponent<Animator>();
        _currentlifeBox--;
        Debug.Log("lifemenus");
        if (_currentlifeBox <= 0)
        {
            anim.SetTrigger("isBroken");
            Destroy(gameObject, 0.3f);
        }
    }
}
