using TMPro;
using UnityEngine;
using YG;

public class GenerateText : MonoBehaviour
{
    public static GenerateText instance;
    public TMP_Text wordDisplay;
    public int currentCharIndex;
    public GameObject textCollider;

    private string[] _words;
    private string currentWord;
    private bool isSpace;
    private float letterWidth;
    private int greenWords;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        currentCharIndex = 0;
        TextAsset textAsset = StartGame.instance.language == 0? Resources.Load<TextAsset>("Russian"): Resources.Load<TextAsset>("English");
        if (textAsset != null)
            _words = textAsset.text.Split(new char[] { ' ', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i <= 5; i++) { ShowNextWord(); }
        isSpace = false;
    }

    private void Update()
    {
        if (currentCharIndex < currentWord.Length)
        {
            if (Input.anyKeyDown)
            {
                string inputString = Input.inputString;

                if (inputString.Length > 0)
                {
                    char inputChar = inputString[0];

                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        inputChar = char.ToUpper(inputChar);

                    if (inputChar == currentWord[currentCharIndex])
                    {
                        float fixSpase = 0;
                        currentCharIndex++;
                        GameScore.instance.currentScore.text = currentCharIndex.ToString();
                        if (currentCharIndex > YandexGame.savesData.bestScoreFast)
                        {
                            YandexGame.savesData.bestScoreFast = currentCharIndex;
                            GameScore.instance.bestScore.text = currentCharIndex.ToString();
                        }

                        char currentLetter = currentWord[currentCharIndex];
                        if (currentLetter != ' ')
                        {
                            fixSpase = isSpace ? 6f : 0;
                            letterWidth = Poiner.instance.GetLetterWidth(currentWord[currentCharIndex]);
                            isSpace = false;
                        }

                        else
                        {
                            letterWidth = 20;
                            greenWords += 1;
                            isSpace = true;
                        }
                        textCollider.GetComponent<IncreaseCollider>().IncreaseColl(letterWidth-fixSpase);

                        UpdateWordDisplay();

                        if (wordDisplay.text.Split().Length-greenWords <= 5)
                        {
                            wordDisplay.rectTransform.sizeDelta = new Vector2(wordDisplay.rectTransform.sizeDelta.x + 200, wordDisplay.rectTransform.sizeDelta.y);
                            ShowNextWord();
                        }
                            
                    }
                }
            }
        }
    }

    private void ShowNextWord()
    {
        currentWord += _words[Random.Range(0, _words.Length)] + " ";
        UpdateWordDisplay();
    }

    private void UpdateWordDisplay()
    {
        string displayedWord = "";
        for (int i = 0; i < currentWord.Length; i++)
        {
            if (i < currentCharIndex)
                displayedWord += "<color=#00FF00>" + currentWord[i] + "</color>";

            else if(i == currentCharIndex)
                displayedWord += "<u>" + currentWord[i] + "</u>";

            else
                displayedWord += currentWord[i];
        }

        wordDisplay.text = displayedWord;
    }
}