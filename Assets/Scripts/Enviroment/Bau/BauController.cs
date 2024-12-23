using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BauController : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;
    public GameObject prefab;

    #region Booleans
    [SerializeField] private bool isOpen;
    [SerializeField] private bool inTrigger;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E) && !isOpen && playerController.totalKeyPoints > 0)
        {
            isOpen = true;
            playerController.totalKeyPoints -= 1;
            anim.SetTrigger("isOpen");
            Instantiate(prefab, transform.position + new Vector3(0f,2f,0f), transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                 inTrigger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
}
