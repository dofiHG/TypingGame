using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculateStates : MonoBehaviour
{
    public static CalculateStates instance;

    [SerializeField] private GameObject _statesPanel;
    [SerializeField] private GameObject _gameElements;
    [SerializeField] private TMP_Text _wordsCountText;
    [SerializeField] private TMP_Text _mistakesCountText;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private TMP_Text _captionText;
    [SerializeField] private Sprite[] _panelPenguins;
    [SerializeField] private Image _mainImage;
    private int speed;
    private float time;

    [HideInInspector] public int wordsCount;
    [HideInInspector] public int mistakesCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        CalculateAverageSpeed();
    }

    private void CalculateAverageSpeed()
    {
        time += Time.deltaTime;
        if (time != 0)
            speed = Convert.ToInt32(TextGenerator.instance.currentCharIndex / time * 60);
    }

    public void OnLoss()
    {
        _captionText.text = "Попробуй ещё!";
        _mainImage.sprite = _panelPenguins[0];
        ShowStates();
    }

    public void OnWin()
    {
        _captionText.text = "Великолепно!";
        _mainImage.sprite = _panelPenguins[1];
        ShowStates();
    }

    private void ShowStates()
    {
        _statesPanel.SetActive(true);
        _gameElements.SetActive(false);
        _wordsCountText.text = wordsCount.ToString();
        _mistakesCountText.text = mistakesCount.ToString();
        _speedText.text = speed.ToString();
    }
}
