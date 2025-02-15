using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public static StartGame instance;

    [HideInInspector] public int language;
    [HideInInspector] public float speed;
    [HideInInspector] public int penguinInt;

    [SerializeField] private Button _startBtn;
    [SerializeField] private TMP_Dropdown _language;
    [SerializeField] private TMP_Dropdown _speedLevel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        _startBtn.onClick.AddListener(StartGameplay);

        language = -1;
        penguinInt = -1;
        speed = -1;
    }

    private void StartGameplay()
    {
        language = _language.value;
        speed = _speedLevel.value + 1;
        penguinInt = GameObject.Find("PenguinChanger").GetComponent<ChangePenguin>().currentIndex;

        if (penguinInt != -1 && language != -1 && speed != -1)
            SceneManager.LoadScene(1);
    }
}
