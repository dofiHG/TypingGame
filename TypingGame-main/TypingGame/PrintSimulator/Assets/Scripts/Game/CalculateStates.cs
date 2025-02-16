using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculateStates : MonoBehaviour
{
    public static CalculateStates instance;

    [SerializeField] private TMP_Text _wordsCountText;
    [SerializeField] private TMP_Text _mistakesCountText;
    [SerializeField] private TMP_Text _speedText;

    [HideInInspector] public int wordsCount;
    [HideInInspector] public int mistakesCount;
    [HideInInspector] public int speed;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ShowStates()
    {
        _wordsCountText.text = wordsCount.ToString();
        _mistakesCountText.text = mistakesCount.ToString();
        _speedText.text = speed.ToString();
    }
}
