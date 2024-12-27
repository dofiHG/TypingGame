using UnityEngine;
using UnityEngine.UI;
using YG;

public class EndGame : MonoBehaviour
{
    public GameObject endPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        endPanel.SetActive(true);    
        GameObject.Find("Plane").GetComponent<CameraMover>().enabled = false;
        GameObject.Find("Player").GetComponent<SquareMover>().enabled = false;
        YandexGame.SaveProgress();
        GameObject.Find("WordsGenerator").GetComponent<GenerateText>().enabled = false;
        GameObject.Find("PauseBtn").GetComponent<Button>().enabled = false;
        GameObject.Find("CalculateAverageSpeed").GetComponent<CalculateAverageSpeed>().enabled = false;
        GameObject.Find("WordsGenerator").GetComponent<GenerateText>().enabled = false;
        YandexGame.SaveProgress();
    }
}
