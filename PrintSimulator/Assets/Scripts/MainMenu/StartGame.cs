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

    private static int _language;
    private static int _speed;

    [SerializeField] private Button _startBtn;
    [SerializeField] private TMP_Dropdown _languageDD;
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

        if (_language != -1 && _speed != -1)
        {
            _languageDD.value = _language;
            _speedLevel.value = _speed;
        }
    }

    public void StartGameplay()
    {
        _language = _languageDD.value;
        _speed = _speedLevel.value;
        penguinInt = GameObject.Find("PenguinChanger").GetComponent<ChangePenguin>().GetCurrentRealIndex();

        language = _language;
        speed = _speed;

        if (penguinInt != -1 && language != -1 && speed != -1)
        {
            GameObject.Find("MainMenuPanel").GetComponent<Animator>().SetBool("Transition", true);
            _gamePanel.SetActive(true);
            _startGame.LevelSetup(penguinInt, speed);
        }
    }
}
