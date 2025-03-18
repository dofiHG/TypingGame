using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenWarningScript : MonoBehaviour
{
    public static OpenWarningScript instance;

    [SerializeField] private GameObject _warningPanel;
    [SerializeField] private Image _warningPanelText;
    [SerializeField] private Sprite[] _warningTexts;
    [SerializeField] private GameObject _penguin;

    private int _mistakesCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            CloseWarningPanel();
        }    
            
    }

    public void OpenWarningPanel(int targetLanguage)
    {
        _warningPanel.SetActive(true);
        _warningPanelText.sprite = _warningTexts[targetLanguage];
        //_warningPanelText.transform.position = new Vector2(_penguin.transform.position.x + 100, 441);
        Time.timeScale = 0;
    }

    private void CloseWarningPanel()
    {
        _warningPanel?.SetActive(false);
        _warningPanelText.sprite = _warningTexts[2];
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
