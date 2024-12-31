using TMPro;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Countdown : MonoBehaviour
{
    public TMP_Text countdownText;
    public static Countdown instance;
    public GameObject player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void StartCountdown()
    {
        GameObject.Find("PauseBtn").GetComponent<PausePanelActiv>().enabled = false;
        countdownText.gameObject.SetActive(true);

        GameObject.Find("Plane").GetComponent<CameraMover>().enabled = false;
        player.GetComponent<SquareMover>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GameObject.Find("CalculateAverageSpeed").GetComponent<CalculateAverageSpeed>().enabled = false;
        GameObject.Find("WordsGenerator").GetComponent<GenerateText>().enabled = false;

        StartCoroutine(CountdownEffect());
    }

    private System.Collections.IEnumerator CountdownEffect()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            PerformEffect();

            yield return new WaitForSeconds(1);
        }
        AfterCountdown();
    }

    private void PerformEffect()
    {
        countdownText.transform.DOScale(3f, 1).From(Vector3.one);
        countdownText.DOFade(0, 1).From(1);
    }

    private void AfterCountdown()
    {
        GameObject.Find("PauseBtn").GetComponent<PausePanelActiv>().enabled = true;
        countdownText.gameObject.SetActive(false);
        GameObject.Find("Plane").GetComponent<CameraMover>().enabled = true;
        player.GetComponent<SquareMover>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GameObject.Find("CalculateAverageSpeed").GetComponent<CalculateAverageSpeed>().enabled = true;
        GameObject.Find("WordsGenerator").GetComponent<GenerateText>().enabled = true;
    }
}
