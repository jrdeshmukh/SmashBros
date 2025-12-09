using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public bool isAttacking = false;
    public float attackX = 50f;
    public float attackY = 10f;
    public bool colliding = false;
    private int myId;

    private void Start()
    {
        myId = GetComponent<PlayerId>().playerId;
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerId otherId = other.gameObject.GetComponent<PlayerId>();
        colliding = true;
        if (otherId == null) {
            colliding = false;
            return;
        };
        isAttacking = false;
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        
        PlayerId otherId = other.gameObject.GetComponent<PlayerId>();
        colliding = true;
        if (otherId == null) {
            colliding = false;
            return;
        };
        Debug.Log($"Collision stay with {other.gameObject.name} and isAttacking: {isAttacking}");

        if (!getIsAttacking()) return;


        
        Rigidbody2D otherRb = other.gameObject.GetComponent<Rigidbody2D>();
        if (otherRb == null) {
            Debug.LogError($"No Rigidbody2D found on {other.gameObject.name}");
            return;
        }
        
        // Apply damage
        GameController.playerHealths[otherId.playerId] *= GameController.playerDamages[myId];
        
        // Calculate force direction based on relative positions
        Vector2 direction = (other.transform.position - transform.position).normalized;
        Vector2 force = new Vector2(
            Mathf.Sign(direction.x) * attackX, 
            attackY);
            
        // Apply force
        otherRb.AddForce(force, ForceMode2D.Impulse);
        Debug.Log($"Applied force: {force} to {other.gameObject.name}");
        Debug.Log($"Rigidbody velocity after force: {otherRb.linearVelocity}");
        isAttacking = false;
    }

    public void setIsAttacking(bool attacking)
    {
        isAttacking = attacking;
    }
    public bool getIsAttacking()
    {
        return isAttacking;
    }

    void Update() {
        // Debug.Log(myId);
        Debug.Log(GameController.playerHealths[0]);
        Debug.Log(GameController.playerHealths[1]);
        Debug.Log(GameController.playerHealths[2]);
        Debug.Log(GameController.playerHealths[3]);
        // gameObject.GetComponent<Rigidbody2D>().mass = GameController.playerHealths[myId];
        if(isAttacking && !colliding) {
            isAttacking = false;
        }
    }


}