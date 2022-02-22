using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI successfulJumps;
    [SerializeField]
    TextMeshProUGUI personalBest;
    [SerializeField]
    TextMeshProUGUI gameOver;
    [SerializeField]
    Button playAgain;
    [SerializeField]
    Button mainMenu;
    [SerializeField]
    Button toggleAccolades;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform maxHeight;
    [SerializeField]
    Transform minHeight;

    Transform ddropestartPos;

    GameObject ropeInst;
    GameObject rope;
    GameObject ddropeInst;
    GameObject ddrope;

    GameObject gbackGround;
    GameObject ropeSpeed;

    Rope ropeCS;
    DoubleDutchRope ddropeCS;

    bool checkforRope;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gbackGround = GameObject.Find("background");
        ropeSpeed = GameObject.FindGameObjectWithTag("options");
        ddropestartPos = GameObject.Find("ddrsp").GetComponent<Transform>();
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        checkforRope = false;
        gameOver.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
        personalBest.text = "Personal Best: " + SaveData.current.profile.numofJumps;
        
        if (player.GetComponent<Player>().getisPlaying())
        {
            toggleAccolades.gameObject.SetActive(false);
            checkforRope = true;
        }

        if (checkforRope)
        {
            rope = GameObject.FindGameObjectWithTag("rope");
            ddrope = GameObject.FindGameObjectWithTag("ddrope");
            if (rope)
            {
                ropeCS = rope.GetComponent<Rope>();
                if (ddrope)
                    ddropeCS = ddrope.GetComponent<DoubleDutchRope>();
                if (ropeCS)
                    checkforRope = false;
            }
        }

        if (ropeCS != null)
        {
            if (ddropeCS != null)
                successfulJumps.text = "jumps: " + (ropeCS.getcurrJumps() + ddropeCS.getcurrJumps());
            else
                successfulJumps.text = "jumps: " + ropeCS.getcurrJumps();
        }

    }

    public TextMeshProUGUI getgameOver()
    {
        return gameOver;
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public void resetGame()
    {
        if (GameObject.Find("Buttons").GetComponent<Difficulties>().getrequestedDifficulty().Equals("dd"))
        {
            rope = Resources.Load<GameObject>("rope");
            ropeInst = Instantiate(rope, maxHeight.position, Quaternion.identity);
            ropeInst.GetComponent<Rope>().setSpeed(ropeSpeed.GetComponent<Slider>().value);
            ddrope = Resources.Load<GameObject>("dd rope");
            ddropeInst = Instantiate(ddrope, ddropestartPos.position, Quaternion.identity);
            ddropeInst.GetComponent<DoubleDutchRope>().setSpeed(ropeSpeed.GetComponent<Slider>().value);
        }
        else
        {
            rope = Resources.Load<GameObject>("rope");
            ropeInst = Instantiate(rope, maxHeight.position, Quaternion.identity);
            ropeInst.GetComponent<Rope>().setSpeed(ropeSpeed.GetComponent<Slider>().value);
        }

        SerializationManager.Save("Data", SaveData.current);
        gbackGround.GetComponent<GameBackground>().resetBackground();
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        toggleAccolades.gameObject.SetActive(false);
        ropeSpeed.gameObject.SetActive(false);
        player.GetComponent<Player>().setisPlaying(true);
        gameOver.text = "";
    }

    public Button getplayAgain()
    {
        return playAgain;
    }
    public Button getmainMenu()
    {
        return mainMenu;
    }
    public Button gettoggleAccolades()
    {
        return toggleAccolades;
    }
    public Slider getropespeedSlider()
    {
        return ropeSpeed.GetComponent<Slider>();
    }
}
