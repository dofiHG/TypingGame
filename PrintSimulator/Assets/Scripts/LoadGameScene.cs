using System.Collections;
using UnityEngine;
using YG;

public class LoadGameScene : MonoBehaviour
{
    private void Awake()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Animator>().SetInteger("Character", StartGame.instance.characterInt);
        GameObject.Find("WordsGenerator").GetComponent<GenerateText>().enabled = true;
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
        Countdown.instance.StartCountdown();
        
    }
}
