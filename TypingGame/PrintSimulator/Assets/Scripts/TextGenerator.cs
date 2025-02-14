using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour
{
    [SerializeField] private TMP_Text _mainText;

    private string _currentText;
    private string[] _textStrings;
    private int _currentCharIndex;

    private void Start()
    {
        SetUp();
    }

    private void SetUp()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("English");
        _textStrings = textAsset.text.Split("\n");
        _currentText = _textStrings[0];

        _currentCharIndex = 0;
        _mainText.text = string.Empty;

        _mainText.text = _currentText;
    }

    private void Update()
    {
        OnTyping();
    }

    private void OnTyping()
    {
        if (Input.anyKeyDown)
        {
            string inputString = Input.inputString;

            if (inputString.Length > 0)
            {
                char inputChar = inputString[0];

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    inputChar = char.ToUpper(inputChar);
                else
                    inputChar = char.ToLower(inputChar);
                
                if (_currentCharIndex < _currentText.Length)
                {
                    if (_currentText[_currentCharIndex] == inputChar)
                    {
                        _currentCharIndex++;
                        PaintCorrectChar();
                        MoveMainText.instance.MoveScroller();
                    }
                    else
                        PaintMistakeChar();
                }
            }
        }
    }

    private void PaintMistakeChar()
    {
        string newText = "";

        if (_currentCharIndex > 0)
            newText += "<color=#BDBDBE>" + _currentText.Substring(0, _currentCharIndex) + "</color>";

        if (_currentCharIndex < _currentText.Length)
            newText += "<color=#D91B1B>" + _currentText[_currentCharIndex] + "</color>";

        if (_currentCharIndex + 1 < _currentText.Length)
            newText += _currentText.Substring(_currentCharIndex + 1);

        _mainText.text = newText;
    }

    private void PaintCorrectChar()
    {
        string newText = "";

        if (_currentCharIndex > 0)
            newText += "<color=#BDBDBE>" + _currentText.Substring(0, _currentCharIndex) + "</color>";

        if (_currentCharIndex < _currentText.Length)
            newText += "<color=#7397EF>" + _currentText[_currentCharIndex] + "</color>";

        if (_currentCharIndex + 1 < _currentText.Length)
            newText += _currentText.Substring(_currentCharIndex + 1);

        _mainText.text = newText;
    }
}
