using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelectorMinecraft : MonoBehaviour
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
        SceneManager.LoadScene("SampleScene 1");
        Debug.Log("Minecraft");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
