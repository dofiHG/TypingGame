using TMPro;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    [SerializeField] private GameObject _darkPanel;
    [SerializeField] private GameObject _textGenerator;

    private void Awake() => Time.timeScale = 0;

    private void Update()
    {
        _textGenerator.SetActive(false);
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            _darkPanel.SetActive(false);
            _textGenerator.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
