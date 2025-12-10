using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    public GameObject MiniPekka;
    public GameObject Skeleton;
    public GameObject Minion;
    public GameObject Hog;
    public GameObject Goblin;
    public GameObject Knight;
    public GameObject Valkyrie;
    public GameObject Barbarian;
    public GameObject Giant;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button mpbtn = mpButton.GetComponent<Button>();
        mpbtn.onClick.AddListener(OnMpButtonClick);

        Button giantbtn = giantButton.GetComponent<Button>();
        giantbtn.onClick.AddListener(OnGiantButtonClick);

        Button goblinbtn = goblinButton.GetComponent<Button>();
        goblinbtn.onClick.AddListener(OnGoblinButtonClick);

        Button skeletonbtn = skeletonButton.GetComponent<Button>();
        skeletonbtn.onClick.AddListener(OnSkeletonButtonClick);

        Button barbarianbtn = barbarianButton.GetComponent<Button>();
        barbarianbtn.onClick.AddListener(OnBarbarianButtonClick);

        Button valkyriebtn = valkyrieButton.GetComponent<Button>();
        valkyriebtn.onClick.AddListener(OnValkyrieButtonClick);

        Button knightbtn = knightButton.GetComponent<Button>();
        knightbtn.onClick.AddListener(OnKnightButtonClick);

        Button hogbtn = hogRiderButton.GetComponent<Button>();
        hogbtn.onClick.AddListener(OnHogButtonClick);

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
        if (Input.GetKey("4"))
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

    public ArrayList playerCharacters = new ArrayList();
    public GameObject Self;

    // Update is called once per frame
    void Update()
    {
        if ((player1 == "Minion" || player1 == "Barbarian" || player1 == "Hog Rider" || player1 == "Goblin" || player1 == "Giant" || player1 == "Skeleton" || player1 == "Mini Pekka" || player1 == "Valkyrie" || player1 == "Knight") &&
            (player2 == "Minion" || player2 == "Barbarian" || player2 == "Hog Rider" || player2 == "Goblin" || player2 == "Giant" || player2 == "Skeleton" || player2 == "Mini Pekka" || player2 == "Valkyrie" || player2 == "Knight") &&
            (player3 == "Minion" || player3 == "Barbarian" || player3 == "Hog Rider" || player3 == "Goblin" || player3 == "Giant" || player3 == "Skeleton" || player3 == "Mini Pekka" || player3 == "Valkyrie" || player3 == "Knight") &&
            (player4 == "Minion" || player4 == "Barbarian" || player4 == "Hog Rider" || player4 == "Goblin" || player4 == "Giant" || player4 == "Skeleton" || player4 == "Mini Pekka" || player4 == "Valkyrie" || player4 == "Knight") &&
            (player1 != player2 && player1 != player3 && player1 != player4 && player2 != player3 && player2 != player4 && player3 != player4))
        {
            playerCharacters.Add(player1);
            playerCharacters.Add(player2);
            playerCharacters.Add(player3);
            playerCharacters.Add(player4);
            Debug.Log(playerCharacters);

            for (int i= 0; i < playerCharacters.Count; i++)
            {
                if (playerCharacters[i] == "Mini Pekka")
                {
                    MiniPekka.GetComponent<PlayerId>().playerId = i;
                    Debug.Log("Mini Pekka" + MiniPekka.GetComponent<PlayerId>().playerId);
                }
                if (playerCharacters[i] == "Giant")
                {
                    Giant.GetComponent<PlayerId>().playerId = i;
                    Debug.Log("Giant" + Giant.GetComponent<PlayerId>().playerId);
                }
                if (playerCharacters[i] == "Goblin")
                {
                    Goblin.GetComponent<PlayerId>().playerId = i;
                    Debug.Log("Goblin" + Goblin.GetComponent<PlayerId>().playerId);
                }
                if (playerCharacters[i] == "Barbarian")
                {
                    Barbarian.GetComponent<PlayerId>().playerId = i;
                    Debug.Log("Barbarian" + Barbarian.GetComponent<PlayerId>().playerId);
                }
                if (playerCharacters[i] == "Valkyrie")
                {
                    Valkyrie.GetComponent<PlayerId>().playerId = i;
                    Debug.Log("Valkyrie" + Valkyrie.GetComponent<PlayerId>().playerId);
                }
                if (playerCharacters[i] == "Minion")
                {
                    Minion.GetComponent<PlayerId>().playerId = i;
                    Debug.Log("Minion" + Minion.GetComponent<PlayerId>().playerId);
                }
                if (playerCharacters[i] == "Knight")
                {
                    Knight.GetComponent<PlayerId>().playerId = i;
                    Debug.Log("Knight" + Knight.GetComponent<PlayerId>().playerId);
                }
                if (playerCharacters[i] == "Hog Rider")
                {
                    Hog.GetComponent<PlayerId>().playerId = i;
                    Debug.Log("Hog" + Hog.GetComponent<PlayerId>().playerId);
                }
                if (playerCharacters[i] == "Skeleton")
                {
                    Skeleton.GetComponent<PlayerId>().playerId = i;
                    Debug.Log("Skeleton" + Skeleton.GetComponent<PlayerId>().playerId);
                }

            }

            Self.SetActive(false);

        }
    }
}
