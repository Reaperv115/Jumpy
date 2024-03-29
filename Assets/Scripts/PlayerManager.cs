using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    GameObject playerGO, playerGOInst;
    bool gameLoaded = false;

    Sprite[] jumpingSprites;
    Sprite[] standingSprites;

    [SerializeField]
    Transform playerPosition;

    int numJumps;
    [HideInInspector]
    public int selectedPlayer;
    [HideInInspector]
    public int selectedjumpingSprite;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Trying to create multiple instances of player manager");

        // load all standing sprites
        standingSprites = Resources.LoadAll<Sprite>("Players/Standing");

        // load and instantiate the player gameobject
        playerGO = Resources.Load<GameObject>("Players/playerGOs/player");
        playerGOInst = Instantiate(playerGO, playerPosition.position, playerGO.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // if the player got caught by the rope, save the num of jumps
        // if it's greater than the previous record
        if (playerGOInst.GetComponent<Player>().GetGotCaught())
            if (numJumps > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = numJumps;
        
        // if there's a valid player gameobject, show the character sprite
        if (playerGOInst)
            playerGOInst.GetComponent<SpriteRenderer>().sprite = standingSprites[selectedPlayer];

        // loading the jumping sprites
        // for the selected character
        if (gameLoaded)
        {
            LoadJumpingSprites(selectedPlayer);
            gameLoaded = false;
        }
    }

    

    public GameObject GetPlayerGO() { return playerGOInst; }
    public Player GetPlayerRef() { return playerGOInst.GetComponent<Player>(); }
    public int GetNumofJumps() { return numJumps; }
    public void SetNumofJumps(int numjumps) { numJumps = numjumps; }
    public Sprite[] GetStandingSprites() { return standingSprites; }
    public Sprite[] GetJumpingSprites()  { return jumpingSprites;  }

    public void SetGameLoaded(bool gameloaded) { gameLoaded = gameloaded; }
    public void LoadJumpingSprites(int playerIndex)
    {
        switch (playerIndex) 
        {
            case 0:
                jumpingSprites = Resources.LoadAll<Sprite>("Players/Alexis/jumping");
                break;
            case 1:
                jumpingSprites = Resources.LoadAll<Sprite>("Players/Ryan/jumping");
                break;
            case 2:
                jumpingSprites = Resources.LoadAll<Sprite>("Players/Tyler/jumping");
                break;
        }
    }
}
