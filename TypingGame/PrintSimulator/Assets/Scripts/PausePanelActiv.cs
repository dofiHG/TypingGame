using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

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

    private CameraMover moverScript;
    private GenerateText generateTextSctipt;

    private void Awake()
    {
        Debug.Log(YandexGame.savesData.currentSpeed);
        if (instance == null)
            instance = this;
        
        flag = true;

        moverScript = GameObject.Find("Plane").GetComponent<CameraMover>();
        generateTextSctipt = GameObject.Find("WordsGenerator").GetComponent<GenerateText>();
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
        moverScript.enabled = true;
        player.GetComponent<SquareMover>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

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

        if (tempSpeed != moverScript.environmentSpeed)
        {
            bestScore.SetActive(false);
            bestScoreTxT.SetActive(false); 
            flag = false;

            moverScript.environmentSpeed = tempSpeed;
            if (player.GetComponent<SquareMover>().speed != 0)
                player.GetComponent<SquareMover>().speed = tempSpeed;
        }

        pausePanel.SetActive(false);
        GameObject.Find("CalculateAverageSpeed").GetComponent<CalculateAverageSpeed>().enabled = true;
        generateTextSctipt.enabled = true;
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        pausePanel.transform.Find("MainText").GetComponent<TMP_Text>().text = "Пауза";
        foreach (Transform child in pausePanel.transform.Find("SpeedPanel").transform)
            child.GetComponentInChildren<Image>().color = new Color32(140, 140, 140, 255);

        switch (moverScript.environmentSpeed)
        {
            case 0.2f: GameObject.Find("Slow").GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255); break;
            case 0.5f: GameObject.Find("Medium").GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255); break;
            case 0.9f: GameObject.Find("Fast").GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255); break;
            case 1.4f: GameObject.Find("VeryFast").GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255); break;
        }

        moverScript.enabled = false;
        player.GetComponent<SquareMover>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GameObject.Find("CalculateAverageSpeed").GetComponent<CalculateAverageSpeed>().enabled = false;
        generateTextSctipt.enabled = false;
    }

    public void ChooseSpeedBtn()
    {
        foreach (Transform child in GameObject.Find("SpeedPanel").transform)
            child.GetComponent<Image>().color = new Color32(140, 140, 140, 255);
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.white;
        ClosePusePanel();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        YandexGame.SaveProgress();
    }
}
