using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public string player1;
    public string player2;
    public string player3;
    public string player4;

    public Button mpButton;
    public Button giantButton;
    public Button minionButton;
    public Button hogRiderButton;
    public Button knightButton;
    public Button goblinButton;
    public Button valkyrieButton;
    public Button barbarianButton;
    public Button skeletonButton;

    MiniPekkaMovement MP;
    SkeletonMovement SM;
    MinionMovement MM;
    HogRiderMovement HR;
    GoblinMovement GM;
    KnightMovement KM;
    ValkyrieMovement VM;
    BarbarianMovement BM;
    GiantMovement GiantM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button mpbtn = mpButton.GetComponent<Button>();
        mpbtn.onClick.AddListener(OnMpButtonClick);

        Button giantbtn = giantButton.GetComponent<Button>();
        giantbtn.onClick.AddListener(OnGiantButtonClick);

        Button goblinbtn = giantButton.GetComponent<Button>();
        goblinbtn.onClick.AddListener(OnGoblinButtonClick);

        Button skeletonbtn = skeletonButton.GetComponent<Button>();
        skeletonbtn.onClick.AddListener(OnSkeletonButtonClick);

        Button barbarianbtn = barbarianButton.GetComponent<Button>();
        barbarianbtn.onClick.AddListener(OnBarbarianButtonClick);

        Button valkyriebtn = mpButton.GetComponent<Button>();
        valkyriebtn.onClick.AddListener(OnValkyrieButtonClick);

        Button knightbtn = knightButton.GetComponent<Button>();
        knightbtn.onClick.AddListener(OnKnightButtonClick);

        Button hogbtn = hogRiderButton.GetComponent<Button>();
        mpbtn.onClick.AddListener(OnHogButtonClick);

        Button minionbtn = minionButton.GetComponent<Button>();
        minionbtn.onClick.AddListener(OnMinionButtonClick);


    }

    public void OnMpButtonClick()
    {
        if (Input.GetKey("1"))
        {
            player1 = "Mini Pekka";
            Debug.Log("Player 1 " + player1);
        }

        if (Input.GetKey("2"))
        {
            player2 = "Mini Pekka";
            Debug.Log("Player 2 " + player2);
        }
        if (Input.GetKey("3"))
        {
            player3 = "Mini Pekka";
            Debug.Log("Player 3 " + player3);
        }
        if (Input.GetKey("3"))
        {
            player4 = "Mini Pekka";
            Debug.Log("Player 4 " + player4);
        }
    }

    public void OnGiantButtonClick()
    {
        if (Input.GetKey("1"))
        {
            player1 = "Giant";
            Debug.Log("Player 1 " + player1);
        }

        if (Input.GetKey("2"))
        {
            player2 = "Giant";
            Debug.Log("Player 2 " + player2);
        }
        if (Input.GetKey("3"))
        {
            player3 = "Giant";
            Debug.Log("Player 3 " + player3);
        }
        if (Input.GetKey("4"))
        {
            player4 = "Giant";
            Debug.Log("Player 4 " + player4);
        }
    }

    public void OnGoblinButtonClick()
    {
        if (Input.GetKey("1"))
        {
            player1 = "Goblin";
            Debug.Log("Player 1 " + player1);
        }

        if (Input.GetKey("2"))
        {
            player2 = "Goblin";
            Debug.Log("Player 2 " + player2);
        }
        if (Input.GetKey("3"))
        {
            player3 = "Goblin";
            Debug.Log("Player 3 " + player3);
        }
        if (Input.GetKey("4"))
        {
            player4 = "Goblin";
            Debug.Log("Player 4 " + player4);
        }
    }

    public void OnSkeletonButtonClick()
    {
        if (Input.GetKey("1"))
        {
            player1 = "Skeleton";
            Debug.Log("Player 1 " + player1);
        }

        if (Input.GetKey("2"))
        {
            player2 = "Skeleton";
            Debug.Log("Player 2 " + player2);
        }
        if (Input.GetKey("3"))
        {
            player3 = "Skeleton";
            Debug.Log("Player 3 " + player3);
        }
        if (Input.GetKey("4"))
        {
            player4 = "Skeleton";
            Debug.Log("Player 4 " + player4);
        }
    }

    public void OnBarbarianButtonClick()
    {
        if (Input.GetKey("1"))
        {
            player1 = "Barbarian";
            Debug.Log("Player 1 " + player1);
        }

        if (Input.GetKey("2"))
        {
            player2 = "Barbarian";
            Debug.Log("Player 2 " + player2);
        }
        if (Input.GetKey("3"))
        {
            player3 = "Barbarian";
            Debug.Log("Player 3 " + player3);
        }
        if (Input.GetKey("4"))
        {
            player4 = "Barbarian";
            Debug.Log("Player 4 " + player4);
        }
    }

    public void OnValkyrieButtonClick()
    {
        if (Input.GetKey("1"))
        {
            player1 = "Valkyrie";
            Debug.Log("Player 1 " + player1);
        }

        if (Input.GetKey("2"))
        {
            player2 = "Valkyrie";
            Debug.Log("Player 2 " + player2);
        }
        if (Input.GetKey("3"))
        {
            player3 = "Valkyrie";
            Debug.Log("Player 3 " + player3);
        }
        if (Input.GetKey("4"))
        {
            player4 = "Valkyrie";
            Debug.Log("Player 4 " + player4);
        }
    }

    public void OnKnightButtonClick()
    {
        if (Input.GetKey("1"))
        {
            player1 = "Knight";
            Debug.Log("Player 1 " + player1);
        }

        if (Input.GetKey("2"))
        {
            player2 = "Knight";
            Debug.Log("Player 2 " + player2);
        }
        if (Input.GetKey("3"))
        {
            player3 = "Knight";
            Debug.Log("Player 3 " + player3);
        }
        if (Input.GetKey("4"))
        {
            player4 = "Knight";
            Debug.Log("Player 4 " + player4);
        }
    }

    public void OnHogButtonClick()
    {
        if (Input.GetKey("1"))
        {
            player1 = "Hog Rider";
            Debug.Log("Player 1 " + player1);
        }

        if (Input.GetKey("2"))
        {
            player2 = "Hog Rider";
            Debug.Log("Player 2 " + player2);
        }
        if (Input.GetKey("3"))
        {
            player3 = "Hog Rider";
            Debug.Log("Player 3 " + player3);
        }
        if (Input.GetKey("4"))
        {
            player4 = "Hog Rider";
            Debug.Log("Player 4 " + player4);
        }
    }

    public void OnMinionButtonClick()
    {
        if (Input.GetKey("1"))
        {
            player1 = "Minion";
            Debug.Log("Player 1 " + player1);
        }

        if (Input.GetKey("2"))
        {
            player2 = "Minion";
            Debug.Log("Player 2 " + player2);
        }
        if (Input.GetKey("3"))
        {
            player3 = "Minion";
            Debug.Log("Player 3 " + player3);
        }
        if (Input.GetKey("4"))
        {
            player4 = "Minion";
            Debug.Log("Player 4 " + player4);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
