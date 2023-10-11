using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourChoice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectDesiredSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectDesiredSpeed()
    {
        gameObject.SetActive(false);
        GameObject slider = UIManager.Instance.GetRopeSpeedSlider().gameObject;
        slider.SetActive(true);
        GameObject basicmodeBtn = UIManager.Instance.GetBasicModeBtn().gameObject;
        basicmodeBtn.SetActive(false);
    }
}