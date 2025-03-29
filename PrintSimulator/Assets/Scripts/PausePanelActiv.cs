using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanelActiv : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject player;
    public TMP_Text averageSpeedPause;
    public TMP_Text averageSpeedDeath;
    public static PausePanelActiv instance;
    public bool flag;
    public GameObject bestScore;
    public GameObject bestScoreTxT;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
        flag = true;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf)
                OpenPausePanel();
            else
                ClosePusePanel();
        }  
    }

    public void ClosePusePanel()
    {
        float tempSpeed = 0;

        foreach (Transform child in pausePanel.transform.Find("SpeedPanel").transform)
        {
            if (child.GetComponent<Image>().color == new Color32(255, 255, 255, 255))
            {
                switch (child.name)
                {
                    case "Slow": tempSpeed = 0.2f; break;
                    case "Medium": tempSpeed = 0.5f; break;
                    case "Fast": tempSpeed = 0.9f; break;
                    case "VeryFast": tempSpeed = 1.4f; break;
                }
            }  
        }

        pausePanel.SetActive(false);
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        pausePanel.transform.Find("MainText").GetComponent<TMP_Text>().text = "Пауза";
        foreach (Transform child in pausePanel.transform.Find("SpeedPanel").transform)
            child.GetComponentInChildren<Image>().color = new Color32(140, 140, 140, 255);


        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GameObject.Find("CalculateAverageSpeed").GetComponent<CalculateAverageSpeed>().enabled = false;
    }

    public void ChooseSpeedBtn()
    {
        foreach (Transform child in GameObject.Find("SpeedPanel").transform)
            child.GetComponent<Image>().color = new Color32(140, 140, 140, 255);
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.white;
        ClosePusePanel();
    }
}
