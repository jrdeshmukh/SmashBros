using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float weight, damage; 

    public bool isDead = false;
    
    private float die = 0; 
    public int deathThreshold = 500;
    // Update is called once per frame
    void Update()
    {

        //If collision
        // add damage
        if (){// if there is a collision with the character
            die = Random.Range(0f, 5f)
            if (damageDealt * die * weight > deathThreshold ){
                isDead = true;
            }
            else(){
                healthPercent += damageDealt; 
            }
        }
        
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
