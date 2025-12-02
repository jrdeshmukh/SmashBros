using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Diagnostics;
public class SkeletonMovement : MonoBehaviour
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

    public int playerId = 0;
    
    private float horizontalMovement;
    private Vector3 velocity = Vector3.zero;
    
    private void Awake()
    {
        
    }
    
    void Update()
    {
        
        // Attack input (Enter key)
        if (!isAttacking && Input.GetKeyDown(KeyCode.Return))
        {
            isAttacking = true;
            gameObject.GetComponent<AttackScript>().setIsAttacking(true);
            StartCoroutine(PekkaAttack());
        }
        
        // Jump input (J key)
        if (Input.GetKeyDown(KeyCode.I) && (isgrounded || jumpCount < maxJumps))
        {
            Jump();
        }
        
        // Horizontal movement (J for left, L for right)
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.J)) moveInput = -1f;  // Move left
        else if (Input.GetKey(KeyCode.L)) moveInput = 1f;  // Move right
        
        if (!isAttacking)
        {
            horizontalMovement = moveInput * Speed * Time.deltaTime;
        }
        else
        {
            horizontalMovement = 0;
        }
        Flip(rb.linearVelocity.x);
        float characterVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("SkeletonSpeed", characterVelocity);
        // UnityEngine.Debug.Log(isgrounded);
        
    }
    
    void FixedUpdate()
    {
        // Horizontal movement (I for left, L for right)
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.J)) moveInput = -1f;  // Move left
        else if (Input.GetKey(KeyCode.L)) moveInput = 1f;  // Move right
        
        if (!isAttacking)
        {
            horizontalMovement = moveInput * Speed * Time.deltaTime;
        }
        else
        {
            horizontalMovement = 0;
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
        // UnityEngine.Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = true;
            jumpCount = 0;
        }
    }
    
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        // UnityEngine.Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = true;
            jumpCount = 0;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        // UnityEngine.Debug.Log("Collision exit with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = false;
        }
    }
    
    public IEnumerator PekkaAttack()
    {
        animator.SetTrigger("SkeletonAttack");
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
            gameObject.GetComponent<AttackScript>().setIsAttacking(true);
            StartCoroutine(PekkaAttack());
        }
    }
}