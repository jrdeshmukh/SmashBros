using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public bool isAttacking = false;
    public float attackX = 50f;
    public float attackY = 20f;
    private int myId;

    private void Start()
    {
        myId = GetComponent<PlayerId>().playerId;
    }

    private void OnColliderEnter2D(Collider2D other)
    {
        if(isAttacking) {
            int otherId = other.GetComponent<PlayerId>().playerId;
            GameController.playerHealths[otherId] *= GameController.playerDamages[myId];
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(attackX, attackY));
        }

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
        gameObject.GetComponent<Rigidbody2D>().mass = GameController.playerHealths[myId];
    }


}