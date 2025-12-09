using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Diagnostics;
public class KnightMovement : MonoBehaviour
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

    private float inputX=0,jumpInput=0,attackInput=0;
    
    private void Awake()
    {
        
    }
    
    void Update()
    {
        int playerId = gameObject.GetComponent<PlayerId>().playerId;
        gameObject.GetComponent<Rigidbody2D>().mass = GameController.playerHealths[playerId];

        
        inputX = GameController.playerInputs[playerId][0];
        jumpInput = GameController.playerInputs[playerId][1];
        attackInput = GameController.playerInputs[playerId][2];
        
        if (!isAttacking)
        {
           if (attackInput > 0)
           {
               isAttacking = true;
               gameObject.GetComponent<AttackScript>().setIsAttacking(true);
               StartCoroutine(PekkaAttack());
           }
        }
        
        // Jump input (J key)
        if (jumpInput > 0 && (isgrounded || jumpCount < maxJumps))
        {
            Jump();
        }
        
        // Horizontal movement (I for left, L for right)
        float moveInput = 0f;
        if (inputX < 0) moveInput = -1f;  // Move left
        else if (inputX > 0) moveInput = 1f;  // Move right
                else {
            moveInput = 0f;
        }
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
        animator.SetFloat("KnightSpeed", characterVelocity);
        // UnityEngine.Debug.Log(isgrounded);
        
    }
    
    void FixedUpdate()
    {
        
        if (!isAttacking)
        {
            horizontalMovement = inputX * Speed * Time.deltaTime;
        }
        else
        {
            horizontalMovement = inputX * 0 * Time.deltaTime;
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
        animator.SetTrigger("KnightAttack");
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