using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour
{
    public static TextGenerator instance;
    public int currentCharIndex;
    public string currentPublicText;

    [SerializeField] private TMP_Text _mainText;
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private GameObject _warningPanelManager;

    private string _currentText;
    private string[] _textStrings;
    private int _language;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        SetUp();
    }

    public void SetUp()
    {
        _language = StartGame.instance.language;

        TextAsset textAsset;
        if (_language == 0)
        {
            textAsset = Resources.Load<TextAsset>("R" + StartGame.instance.speed);
        }

        else
        {
            textAsset = Resources.Load<TextAsset>("E" + StartGame.instance.speed);
        }
        //textAsset = _language == 1? Resources.Load<TextAsset>("English") : Resources.Load<TextAsset>("Russian");

        _textStrings = textAsset.text.Split("\n");
        int rangomString = Random.Range(0, _textStrings.Length - 1);
        _currentText = _textStrings[rangomString];
        currentPublicText = _currentText;

        currentCharIndex = 0;
        _mainText.text = string.Empty;

        _mainText.text = _currentText;

        _progressSlider.maxValue = _currentText.Length - 1;
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
                    (bool isValid, int targetLanguage) = CheckLanguage.instance.CheckSymbol(inputChar, _language);
                    if (!isValid)
                    {
                        _warningPanelManager.SetActive(true);
                        OpenWarningScript.instance.OpenWarningPanel(targetLanguage);
                        return;
                    }

                    char currentChar = _currentText[currentCharIndex];

                    if (currentChar == '«' || currentChar == '»')
                        currentChar = '"';

                    if (currentChar == inputChar)
                    {
                        if (currentCharIndex == _currentText.Length - 2)
                            StartCoroutine(DelayBeforeWin());

                        if (currentChar == ' ')
                            CalculateStates.instance.wordsCount++;

                        currentCharIndex++;

                        PaintCorrectChar();
                        PenguinMover.instance.MovePenguin(currentPublicText.Length);

                        if (currentCharIndex > 15)
                            MoveMainText.instance.MoveScroller();

                        IceMoverUp currentIce = FindCurrentIce();
                        if (currentIce != null)
                        {
                            currentIce.Move();
                        }

                        _progressSlider.value += 1;
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
        {
            char currentChar = _currentText[currentCharIndex];
            if (currentChar == ' ')
                newText += "<color=#D91B1B>_</color>";
            else
                newText += "<color=#D91B1B>" + currentChar + "</color>";
        }

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

    private IceMoverUp FindCurrentIce()
    {
        IceMoverUp[] iceMovers = FindObjectsOfType<IceMoverUp>();
        foreach (IceMoverUp ice in iceMovers)
        {
            if (ice.enabled)
                return ice;
        }
        return null;
    }

    private IEnumerator DelayBeforeWin()
    {
        yield return new WaitForSeconds(0.25f);
        CalculateStates.instance.OnWin();
    }
}
