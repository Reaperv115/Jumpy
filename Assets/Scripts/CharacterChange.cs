using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    GameObject player;
    Transform playerPos;

    Sprite[] playerSprites;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("player starting point"))
        {
            if (GameObject.Find("player starting point").GetComponent<HasPlayed>().player.GetComponent<Player>().returnhasPlayed())
            {
                Destroy(GameObject.Find("player starting point"));
                playerSprites = Resources.LoadAll<Sprite>("Players");
            }
        }
        else
        {
            playerPos = GameObject.Find("player position").GetComponent<Transform>();
            Debug.Log(playerPos.position);
            player = Resources.Load<GameObject>("Players/playerGOs/player");
            Instantiate(player, playerPos.position, Quaternion.identity);
            playerSprites = Resources.LoadAll<Sprite>("Players");
        }

    }
}
