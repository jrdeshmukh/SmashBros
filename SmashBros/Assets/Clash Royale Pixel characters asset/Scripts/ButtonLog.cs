using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLog : MonoBehaviour {
    public void Update() {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
        if (Input.GetKeyDown(keyCode))
        {
        // Handle the pressed key
        Debug.Log("Key pressed: " + keyCode.ToString());
        break; // Exit the loop once a key is detected
        }
        }
    }
}