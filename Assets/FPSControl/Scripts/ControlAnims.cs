using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class ControlAnims : MonoBehaviour
{
    [SerializeField]
    private RigidbodyFirstPersonController controller;
    [SerializeField]
    private Animator animator;
    private bool isWalking;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        /* if (controller.Velocity.sqrMagnitude > 0.5)
         {
             isWalking = true;
         }
         else isWalking = false;


         */     
        animator.SetBool("isWalking", true);

        if (controller.Velocity.sqrMagnitude > 0.5)
        {
            animator.speed = 1.5f;
        }
        else animator.speed = 0;


    }
}
