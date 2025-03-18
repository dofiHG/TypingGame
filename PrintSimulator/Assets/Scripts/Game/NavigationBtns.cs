using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationBtns : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _penguin;
    [SerializeField] private GameObject _statesPanel;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Scrollbar _textScroll;
    [SerializeField] private GameObject _iceContainer;
    [SerializeField] private GameObject _darkPanel;
    [SerializeField] private GameObject _darkPanelManager;

    private List<Transform> _ices = new List<Transform>();
    private List<Vector3> _icesPositions = new List<Vector3>();

    private Vector2 _penguinDefaultPosition;

    private void Start()
    {
        _penguinDefaultPosition = _penguin.transform.localPosition;

        foreach (Transform ice in _iceContainer.transform)
        {
            _ices.Add(ice);
            _icesPositions.Add(ice.position);
        }
    }

    public void Retry()
    {
        TextGenerator.instance.SetUp();
        _penguin.transform.localPosition = _penguinDefaultPosition;
        _gamePanel.SetActive(true);
        CalculateStates.instance.mistakesCount = 0;
        CalculateStates.instance.wordsCount = 0;
        _progressBar.value = 0;
        _textScroll.value = 0;
        RecoverIces();
        _darkPanel.SetActive(true);
        _darkPanelManager.SetActive(true);
        _statesPanel.SetActive(false);
    }

    public void Menu() => SceneManager.LoadScene(0);

    private void RecoverIces()
    {
        float speed = _ices[_ices.Count - 1].GetComponent<IceMoverBack>().speed;
        for (int i = 0; i < _ices.Count; i++)
        {
            _ices[i].position = _icesPositions[i];
            _ices[i].rotation = Quaternion.identity;
            _ices[i].GetComponent<BoxCollider2D>().enabled = true;
            _ices[i].GetComponent<IceMoverBack>().speed = speed;
            _ices[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _ices[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
