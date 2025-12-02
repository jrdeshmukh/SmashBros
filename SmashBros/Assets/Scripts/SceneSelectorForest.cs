using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneSelectorForest : MonoBehaviour
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
        SceneManager.LoadScene("Map 2");
        Debug.Log("Forest");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
