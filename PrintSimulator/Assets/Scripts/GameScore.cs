using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class GameScore : MonoBehaviour
{
    public static GameScore instance;   
    public TMP_Text bestScore;
    public TMP_Text currentScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        currentScore.text = "0";
        switch (StartGame.instance.speed)
        {
            case 0.2f: bestScore.text = YandexGame.savesData.bestScoreSlow.ToString(); break;
            case 0.5f: bestScore.text = YandexGame.savesData.bestScoreMedium.ToString(); break;
            case 0.9f: bestScore.text = YandexGame.savesData.bestScoreFast.ToString(); break;
            case 1.4f: bestScore.text = YandexGame.savesData.bestScoreVeryFast.ToString(); break;
        }
    }
}
