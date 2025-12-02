using UnityEngine;
using UnityEngine.UI;   // Needed for Text UI

public class Health : MonoBehaviour
{
    public int maxHits = 12;     // total hits character can take
    private int currentHits = 0; // tracks how many times character got hit

    
    public Canvas canvas;     // Canvas with UI elements
    public Text knockoutText;
    void Start()
    {
        if (knockoutText != null)
            knockoutText.gameObject.SetActive(false); // hide at start
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        currentHits++;

        if (currentHits >= maxHits)
        {
            KnockOut();
        }
    }

    void KnockOut()
    {
        
        if (knockoutText != null)
        {
            knockoutText.text = "KNOCK OUT!";
            knockoutText.gameObject.SetActive(true);
            
        }

        // Remove character
        Destroy(gameObject);
    }
}