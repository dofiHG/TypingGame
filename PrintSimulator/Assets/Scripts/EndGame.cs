using UnityEngine;
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
    }
}
