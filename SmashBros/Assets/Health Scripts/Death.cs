using UnityEngine;
using UnityEngine.UI;

public class FallDeath : MonoBehaviour
{
    public float deathY = -10f;   
    public Canvas knockoutCanvas;  
    public Canvas gameOverCanvas;   

    public float lives = 2f;

    public Vector3 spawn;

    void Start()
    {
        
        if (knockoutCanvas != null)
            knockoutCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (transform.position.y < deathY)
        {
            KnockOut();
        }
    }

    void KnockOut()
    {
        if (knockoutCanvas != null)
        {
            knockoutCanvas.gameObject.SetActive(true);
        }

        gameObject.SetActive(false);
        if (lives > 0)
        {
            Invoke("Respawn", 2f);
        }
        else{
            Invoke("GameOver", 2f);
        }

    }
    void GameOver()
    {
        knockoutCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);

    }

    void Respawn()
    {

        knockoutCanvas.gameObject.SetActive(false);
        GameController.playerHealths = new float[]{1,1};
        gameObject.SetActive(true);
        transform.position = spawn;
        lives--;
    }
}
