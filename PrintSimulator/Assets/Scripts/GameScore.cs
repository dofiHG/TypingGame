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
        bestScore.text = YandexGame.savesData.bestScoreFast.ToString();
    }
}
