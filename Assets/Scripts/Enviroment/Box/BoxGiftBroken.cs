using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGiftBroken : MonoBehaviour
{
    [SerializeField] private float _lifeBox;
    [SerializeField] private float _currentLifBox;
    [SerializeField] private List<GameObject> prefabs;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        _currentLifBox = _lifeBox;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null && playerController.isJumping) 
            {
                TakeDamage();
            }
        }
    }

    void TakeDamage()
    {
        anim = GetComponent<Animator>();
        _currentLifBox--;
        anim.SetTrigger("isHit"); 
        if (_currentLifBox <= 0)
        {
            anim.SetTrigger("isBreak");
            Destroy(gameObject, 0.3f);
            Instantiate(prefabs[0], transform.position + new Vector3(0f, -1f, 0f), transform.rotation);
        }
    }
}
