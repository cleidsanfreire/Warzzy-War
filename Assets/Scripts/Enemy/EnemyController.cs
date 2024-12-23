using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float _healthTotal = 3;
    [SerializeField] private float _currentHealth;

    public float healthTotal { get => _healthTotal; set => _healthTotal = value; }
    public float currentHealth { get => _currentHealth; set => _currentHealth = value; }

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _healthTotal;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                TakeDamage();
            }
            playerController.isGrounded = true;
            playerController.isJumping = false;
        }
    }

    void TakeDamage()
    {
        currentHealth--;
        anim.SetTrigger("isHit");
        if (currentHealth <= 0)
        {
            anim.SetTrigger("isDeath");
            Destroy(gameObject, 0.4f);
        }
    }
}
