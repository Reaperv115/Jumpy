using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadGameScene);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        GameManager.instance.SwitchScenes(true);
    }
}
