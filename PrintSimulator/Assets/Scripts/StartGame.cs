using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class StartGame : MonoBehaviour
{
    public static StartGame instance;
    public int language = -1;

    private int characterInt = -1;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void ChooseCharacter()
    {
        string characterName = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name;
        foreach (Transform child in GameObject.Find("Characters").transform)
            child.gameObject.GetComponent<Image>().color = new Color32(140, 140, 140, 255);

        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.white;
        
        switch (characterName)
        {
            case "Squirrell":
                characterInt = 0; break;
            case "Car":
                characterInt = 1; break;
            case "Pig":
                characterInt = 2; break;
            case "Dragon":
                characterInt = 3; break;
        }
    }

    public void StartGames()
    {
        YandexGame.savesData.character = characterInt;
        SceneManager.LoadScene(1);
    }

    public void ChooseLang()
    {
        string langName = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name;
        language = langName == "Rus" ? 0 : 1;

        if (language == 0)
        {
            GameObject.Find("Rus").GetComponent<Image>().color = Color.white;
            GameObject.Find("Eng").GetComponent<Image>().color = new Color(190, 190, 190, 255);
            Debug.Log(1);
        }
        else
        {
            GameObject.Find("Rus").GetComponent<Image>().color = new Color(190, 190, 190, 255);
            GameObject.Find("Eng").GetComponent<Image>().color = Color.white;
            Debug.Log(2);
        }
    }
}
