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
    
    private float horizontalMovement;
    private Vector3 velocity = Vector3.zero;

    private float inputX=0,jumpInput=0,attackInput=0;
    
    private void Awake()
    {
        
    }
    
    void Update()
    {
        GameController.UpdateInputs();
        try
        {
            // UnityEngine.Debug.Log("[SkeletonMovement] Starting Update");
            
            PlayerId playerIdComponent = gameObject.GetComponent<PlayerId>();
            // if (playerIdComponent == null)
            // {
            //     UnityEngine.Debug.LogError($"[SkeletonMovement] PlayerId component not found on {gameObject.name}");
            //     return;
            // }
            
            int playerId = playerIdComponent.playerId;
            gameObject.GetComponent<Rigidbody2D>().mass = GameController.playerHealths[playerId];
            // UnityEngine.Debug.Log($"[SkeletonMovement] Player ID: {playerId}");
            
            // if (GameController.playerInputs == null)
            // {
            //     UnityEngine.Debug.LogError("[SkeletonMovement] playerInputs is null in GameController");
            //     return;
            // }
            
            // UnityEngine.Debug.Log($"[SkeletonMovement] playerInputs length: {GameController.playerInputs.Length}");
            
            // if (playerId < 0 || playerId >= GameController.playerInputs.Length)
            // {
            //     UnityEngine.Debug.LogError($"[SkeletonMovement] Invalid playerId: {playerId}. playerInputs length: {GameController.playerInputs.Length}");
            //     return;
            // }
            
            // UnityEngine.Debug.Log($"[SkeletonMovement] Accessing playerInputs[{playerId}]");
            float[] playerInput = GameController.playerInputs[playerId];
            
            // if (playerInput == null || playerInput.Length < 3)
            // {
            //     UnityEngine.Debug.LogError($"[SkeletonMovement] playerInputs[{playerId}] is null or too small. Length: {playerInput?.Length ?? 0}");
            //     return;
            // }
            
            inputX = playerInput[0];
            jumpInput = playerInput[1];
            attackInput = playerInput[2];
            
            // UnityEngine.Debug.Log($"[SkeletonMovement] Inputs - X: {inputX}, Jump: {jumpInput}, Attack: {attackInput}");
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError($"[SkeletonMovement] Error in Update: {e.Message}\n{e.StackTrace}");
            return;
        }
        
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
        animator.SetFloat("SkeletonSpeed", characterVelocity);
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