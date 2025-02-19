using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TextGenerator : MonoBehaviour
{
    public static TextGenerator instance;
    public int currentCharIndex;
    public string currentPublicText;

    [SerializeField] private TMP_Text _mainText;

    private string _currentText;
    private string[] _textStrings;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        SetUp();
    }

    private void SetUp()
    {
        TextAsset textAsset = StartGame.instance.language == 1? Resources.Load<TextAsset>("English") : Resources.Load<TextAsset>("Russian");
        _textStrings = textAsset.text.Split("\n");
        int rangomString = Random.Range(0, _textStrings.Length - 1);
        _currentText = _textStrings[rangomString];
        currentPublicText = _currentText;

        currentCharIndex = 0;
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
                
                if (currentCharIndex < _currentText.Length)
                {
                    if (_currentText[currentCharIndex] == inputChar)
                    {
                        IceMover.instance.Move();
                        if (currentCharIndex == _currentText.Length - 2)
                            CalculateStates.instance.OnWin();

                        if (_currentText[currentCharIndex] == ' ')
                            CalculateStates.instance.wordsCount++;

                        currentCharIndex++;

                        PaintCorrectChar();
                        if (currentCharIndex > 15)
                            MoveMainText.instance.MoveScroller();
                        
                    }
                    else
                    {
                        PaintMistakeChar();
                        CalculateStates.instance.mistakesCount++;
                    }   
                }
            }
        }
    }

    private void PaintMistakeChar()
    {
        string newText = "";

        if (currentCharIndex > 0)
            newText += "<color=#BDBDBE>" + _currentText.Substring(0, currentCharIndex) + "</color>";

        if (currentCharIndex < _currentText.Length)
            newText += "<color=#D91B1B>" + _currentText[currentCharIndex] + "</color>";

        if (currentCharIndex + 1 < _currentText.Length)
            newText += _currentText.Substring(currentCharIndex + 1);

        _mainText.text = newText;
    }

    private void PaintCorrectChar()
    {
        string newText = "";

        if (currentCharIndex > 0)
            newText += "<color=#BDBDBE>" + _currentText.Substring(0, currentCharIndex) + "</color>";

        if (currentCharIndex < _currentText.Length)
            newText += "<color=#7397EF>" + _currentText[currentCharIndex] + "</color>";

        if (currentCharIndex + 1 < _currentText.Length)
            newText += _currentText.Substring(currentCharIndex + 1);

        _mainText.text = newText;
    }
}
