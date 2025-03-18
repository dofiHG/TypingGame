using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public static StartGame instance;

    [HideInInspector] public int language;
    [HideInInspector] public int speed;
    [HideInInspector] public int penguinInt;

    [SerializeField] private Button _startBtn;
    [SerializeField] private TMP_Dropdown _language;
    [SerializeField] private TMP_Dropdown _speedLevel;
    [SerializeField] private SetupGame _startGame;
    [SerializeField] private GameObject _gamePanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        _startBtn.onClick.AddListener(StartGameplay);

        penguinInt = -1;
        language = PlayerPrefs.GetInt("Language", -1);
        speed = PlayerPrefs.GetInt("Speed", -1);

        if (language != -1 && speed != -1)
        {
            _language.value = language;
            _speedLevel.value = speed;
        }
    }

    public void StartGameplay()
    {
        language = _language.value;
        speed = _speedLevel.value;
        penguinInt = GameObject.Find("PenguinChanger").GetComponent<ChangePenguin>().GetCurrentRealIndex();

        PlayerPrefs.SetInt("Language", language);
        PlayerPrefs.SetInt("Speed", speed);
        PlayerPrefs.Save();

        if (penguinInt != -1 && language != -1 && speed != -1)
        {
            GameObject.Find("MainMenuPanel").GetComponent<Animator>().SetBool("Transition", true);
            _gamePanel.SetActive(true);
            _startGame.LevelSetup(penguinInt, speed);
        }
    }
}
