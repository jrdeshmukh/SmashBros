using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MiniPekkaSelect : MonoBehaviour
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
        if (Input.GetKey("1"))
        {
            Debug.Log("1 = Mini Pekka");
        }

        if (Input.GetKey("2"))
        {
            Debug.Log("2 = Mini Pekka");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
