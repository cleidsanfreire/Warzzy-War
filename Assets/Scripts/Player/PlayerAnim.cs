using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.moviment.sqrMagnitude > 0)
        {
            anim.SetInteger("iTransition", 1);
        }
        else
        {
            anim.SetInteger("iTransition", 0);
        }

        if (playerController.moviment.x > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (playerController.moviment.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f); 
        }

        OnJump();
    }

    public void OnJump()
    {
        if (playerController.isJumping)
        {
            anim.SetBool("isJump", true);
        } 
        if (!playerController.isJumping)
        {
            anim.SetBool("isJump", false);
        }
    }

}
