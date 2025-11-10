using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    public float Speed;
    public float Damage = 10;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;


    private bool isAttacking = false;



    private float horizontalMovement;
    private Vector3 velocity = Vector3.zero;
    private void Awake()
    {

    }

    void Update()
    {

        if (!isAttacking)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isAttacking = true;
                StartCoroutine(PekkaAttack());
            }
        }

        if (!isAttacking)
        {
            horizontalMovement = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        }
        else
        {
            horizontalMovement = Input.GetAxis("Horizontal") * 0 * Time.deltaTime;
        }

        Flip(rb.linearVelocity.x);
        float characterVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("GoblinSpeed", characterVelocity);



    }

    void FixedUpdate()
    {

        if (!isAttacking)
        {
            horizontalMovement = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        }
        else
        {
            horizontalMovement = Input.GetAxis("Horizontal") * 0 * Time.deltaTime;
        }


        MoveMiniPekka(horizontalMovement);





    }

    void MoveMiniPekka(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);

    }

    void Flip(float _velocity)
    {
        if (!isAttacking)
        {
            if (_velocity > 0.1f)
            {
                spriteRenderer.flipX = false;

            }
            else if (_velocity < -0.1f)
            {
                spriteRenderer.flipX = true;

            }
        }

    }

    public IEnumerator PekkaAttack()
    {
        animator.SetTrigger("GoblinAttack");
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
