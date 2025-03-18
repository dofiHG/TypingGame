using UnityEngine;

public class CheckLanguage : MonoBehaviour
{
    public static CheckLanguage instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public (bool, int) CheckSymbol(char symbol, int language)
    {
        int symbolLanguage = -1;
        if ((symbol >= 'à' && symbol <= 'ÿ') || (symbol >= 'À' && symbol <= 'ß') || symbol == '¸' || symbol == '¨')
        {
            symbolLanguage = 0;
            return CheckCurrentLanguage(language, symbolLanguage);
        }

        if ((symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z'))
        {
            symbolLanguage = 1;
            return CheckCurrentLanguage(language, symbolLanguage);
        }

        return (true, -1);   
    }

    public (bool, int) CheckCurrentLanguage(int language, int symbolLanguage)
    {
        if (language == symbolLanguage)
            return (true, -1);

        if (symbolLanguage == 0)
            return (false, 0);

        return (false, 1);
    }
}
