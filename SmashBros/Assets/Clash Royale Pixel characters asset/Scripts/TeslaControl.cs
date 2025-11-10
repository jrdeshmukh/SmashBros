using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaControl : MonoBehaviour
{


    
    public float Damage = 10;
    
    public SpriteRenderer spriteRenderer;
    public Animator animator;


    private bool isAttacking = false;



    
    private void Awake()
    {

    }

    void Update()
    {

        if (!isAttacking)
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("TeslaPosition");
            }
        }

        

        



    }

    void FixedUpdate()
    {

        





    }

    void MoveMiniPekka(float _horizontalMovement)
    {
        

    }

    

    

    public IEnumerator PekkaAttack()
    {
        animator.SetTrigger("MiniPekkaAttack");
        yield return new WaitForSeconds(.4f);
        isAttacking = false;
    }

    public void ResetAnimation()
    {
        animator.Rebind();
    }

    public void Attack()
    {

        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(PekkaAttack());
        }
    }
}
