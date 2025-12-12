using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float[] playerHealths = new float[]{1,1,1,1};
    public static float[] playerDamages = new float[]{0.9f, 0.9f, 0.9f, 0.9f};

    private static bool isInitialized = false;
    public static float[][] playerInputs = new float[4][] { new float[3], new float[3], new float[3], new float[3] };

    private void Awake()
    {
        InitializeInputs();
    }

    private static void InitializeInputs()
    {
        if (!isInitialized)
        {
            for (int i = 0; i < playerInputs.Length; i++)
            {
                if (playerInputs[i] == null || playerInputs[i].Length < 3)
                {
                    playerInputs[i] = new float[3];
                }
            }
            isInitialized = true;
        }
    }

    public static void UpdateInputs()  {
        InitializeInputs();
        GameController.playerInputs[0][0] = Input.GetKey(KeyCode.A)?-1f:Input.GetKey(KeyCode.D)?1f:0f;
        GameController.playerInputs[0][1] = Input.GetKey(KeyCode.W) ? 1f : 0f;
        GameController.playerInputs[0][2] = Input.GetKey(KeyCode.Space) ? 1f : 0f;
        
        GameController.playerInputs[1][0] = Input.GetKey(KeyCode.J)?-1f:Input.GetKey(KeyCode.L)?1f:0f;
        GameController.playerInputs[1][1] = Input.GetKey(KeyCode.I) ? 1f : 0f;
        GameController.playerInputs[1][2] = Input.GetKey(KeyCode.Return) ? 1f : 0f;

        float c1x = Input.GetAxis("Controller1X");
        float c2x = Input.GetAxis("Controller2X");

        GameController.playerInputs[3][0] = Mathf.Abs(c2x)>0.2?c2x:0;
        GameController.playerInputs[3][1] = Input.GetKey(KeyCode.Joystick2Button1) ? 1f : 0f;
        GameController.playerInputs[3][2] = Input.GetKey(KeyCode.Joystick2Button5) ? 1f : 0f;

        
        GameController.playerInputs[2][0] = Mathf.Abs(c1x)>0.2?c1x:0;
        GameController.playerInputs[2][1] = Input.GetKey(KeyCode.JoystickButton1) ? 1f : 0f;
        GameController.playerInputs[2][2] = Input.GetKey(KeyCode.JoystickButton5) ? 1f : 0f;

        for(int i = 0; i < 3; i++) {
            if(playerInputs[2][i]==playerInputs[3][i]){
                playerInputs[2][i] = 0f;
            }
        }
        

        // Debug.Log(GameController.playerInputs[2][0]);
        // Debug.Log(GameController.playerInputs[3][0]);

    }

    public void Update()
    {
        UpdateInputs();
    }
}