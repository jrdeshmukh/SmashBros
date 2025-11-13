using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Diagnostics;
public class MiniPekkaMovement : MonoBehaviour
{
    
    
    public float Speed;
    public float JumpForce = 20f;
    public float Damage = 10;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    
    private bool isAttacking = false;
    private bool isgrounded = false;
    private int jumpCount = 0;
    private int maxJumps = 1;
    
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
        
        // Jump input
        if (Input.GetButtonDown("Vertical") && (isgrounded || jumpCount < maxJumps))
        {
            Jump();
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
        animator.SetFloat("MiniPekkaSpeed", characterVelocity);
        UnityEngine.Debug.Log(isgrounded);
        
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
    
    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        jumpCount++;
        isgrounded = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = true;
            jumpCount = 0;
        }
    }
    
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = true;
            jumpCount = 0;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("Collision exit with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = false;
        }
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