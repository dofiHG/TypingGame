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

    private int _mistakes;

    private int _mistakesCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
            CloseWarningPanel();    
    }

    public void OpenWarningPanel(int targetLanguage)
    {
        TextGenerator.instance.gameObject.SetActive(false);
        _warningPanel.SetActive(true);
        _warningPanelText.sprite = _warningTexts[targetLanguage];
        Time.timeScale = 0;
    }

    private void CloseWarningPanel()
    {
        _warningPanel?.SetActive(false);
        _warningPanelText.sprite = _warningTexts[2];
        Time.timeScale = 1;
        TextGenerator.instance.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
