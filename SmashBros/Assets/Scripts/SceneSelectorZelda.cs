using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelectorZelda : MonoBehaviour
{
    public Button yourButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    { 
        SceneManager.LoadScene("Zelda Map");
        Debug.Log("Zelda");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
