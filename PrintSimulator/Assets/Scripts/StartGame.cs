using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class StartGame : MonoBehaviour
{
    public static StartGame instance;
    public int language;
    public float speed;

    private int characterInt;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        language = -1;
        characterInt = -1;
        speed = -1;
    }

    public void ChooseCharacter()
    {
        string characterName = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name;
        foreach (Transform child in GameObject.Find("Characters").transform)
            if (child.GetComponent<Button>() != null)
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
        if (CheckValidChoise())
        {
            YandexGame.savesData.character = characterInt;
            SceneManager.LoadScene(1);
        }
        else
        {
            gameObject.GetComponentInChildren<TMP_Text>().text = "Закончи выбор!";
            StartCoroutine(Delay());
        }
    }

    public void ChooseLang()
    {
        string langName = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name;
        language = langName == "Rus" ? 0 : 1;

        if (language == 0)
        {
            GameObject.Find("Rus").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("Eng").GetComponent<Image>().color = new Color32(190, 190, 190, 255);
        }
        else
        {
            GameObject.Find("Rus").GetComponent<Image>().color = new Color32(190, 190, 190, 255);
            GameObject.Find("Eng").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void ChooseSpeedLvL()
    {
        foreach (Transform child in GameObject.Find("SpeedPanel").transform)
            child.GetComponent<Image>().color = new Color32(191, 191, 191, 255);
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.white;

        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "LightSpeed": speed = 0.2f; break;
            case "MediumSpeed": speed = 0.5f; break;
            case "HardSpeed": speed = 0.9f; break;
            case "VeryHardSpeed": speed = 1.4f; break;
        }
    }

    private bool CheckValidChoise()
    {
        if (language != -1 && characterInt != -1 && speed != -1)
            return true;
        return false;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        gameObject.GetComponentInChildren<TMP_Text>().text = "Начать забег";
    }
}
