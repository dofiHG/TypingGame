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

    public float GetLetterWidth(char letter)
    {
        TMP_Text tempSymbol = Instantiate(_tempText, GameObject.Find("GameElements").GetComponent<Transform>());
        tempSymbol.text = letter.ToString();

        tempSymbol.GetComponent<RectTransform>().sizeDelta = new Vector2(tempSymbol.preferredWidth, tempSymbol.preferredHeight);

        float letterWidth = tempSymbol.preferredWidth;
        Destroy(tempSymbol.gameObject);
        return letterWidth;
    }
}
