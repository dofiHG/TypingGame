using System;
using TMPro;
using UnityEngine;

public class Poiner : MonoBehaviour
{
    [SerializeField] private TMP_Text _tempText;

    public static Poiner instance;

    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    private void Start()
    {
        transform.position = new Vector2(-4.69f, -0.7f);
    }

    public void MovePointer(float width)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + width, transform.localPosition.y);
    }

    public void ScalePointer(float width)
    {
        transform.localScale = new Vector2(width, transform.localScale.y);
    }

    public float GetLetterWidth(char letter)
    {
        TMP_Text tempSymbol = Instantiate(_tempText, GameObject.Find("Canvas").GetComponent<Transform>());
        tempSymbol.text = letter.ToString();
        tempSymbol.GetComponent<RectTransform>().sizeDelta = new Vector2(tempSymbol.preferredWidth, tempSymbol.preferredHeight);

        float letterWidth = tempSymbol.preferredWidth;

        Destroy(tempSymbol);
        return letterWidth;
    }
}
