using UnityEngine;
using UnityEngine.UI;

public class ReplayGame : MonoBehaviour
{
    [SerializeField]
    GameObject backGround;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReloadGame);
    }

    void ReloadGame()
    {
        SerializationManager.Save("Data", SaveData.current);
        UIManager.Instance.GetBasicModeOptions().SetActive(true);
        UIManager.Instance.GetYourChoiceBtn().SetActive(true);
        PlayerManager.Instance.SetNumofJumps(0);
        gameObject.SetActive(false);
    }
}
