using TMPro;
using UnityEngine;

public class GenerateText : MonoBehaviour
{
    public TMP_Text wordDisplay;
    public int currentCharIndex;

    private string[] _words;
    private string currentWord;
    private bool isSpace;

    private void Start()
    {
        currentCharIndex = 0;
        TextAsset textAsset = Resources.Load<TextAsset>("Russian");
        if (textAsset != null)
            _words = textAsset.text.Split(new char[] { ' ', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        ShowNextWord();
        float letterWidth = Poiner.instance.GetLetterWidth(currentWord[0]);
        Poiner.instance.ScalePointer(letterWidth);
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
                        int fixSpase = 0;
                        currentCharIndex++;
                        float letterWidth;
                        char currentLetter = currentWord[currentCharIndex];
                        if (currentLetter != ' ')
                        {
                            fixSpase = isSpace? 5 : 0;
                            letterWidth = Poiner.instance.GetLetterWidth(currentWord[currentCharIndex]);
                            Poiner.instance.MovePointer((Poiner.instance.GetLetterWidth(currentWord[currentCharIndex - 1]) / 2 + Poiner.instance.GetLetterWidth(currentWord[currentCharIndex]) / 2) + fixSpase);
                            isSpace = false;
                        }

                        else
                        {
                            letterWidth = 20;
                            Poiner.instance.MovePointer(Poiner.instance.GetLetterWidth(currentWord[currentCharIndex - 1]) / 2 + 10);
                            isSpace = true;
                        }

                        
                        Poiner.instance.ScalePointer(letterWidth);
                        UpdateWordDisplay();

                        if (currentCharIndex >= currentWord.Length-1)
                            ShowNextWord();
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
            {
                displayedWord += "<color=#00FF00>" + currentWord[i] + "</color>";
            }
            else
            {
                displayedWord += currentWord[i];
            }
        }

        wordDisplay.text = displayedWord;
    }
}
