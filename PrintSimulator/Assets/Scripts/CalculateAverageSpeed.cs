using System;
using TMPro;
using UnityEngine;

public class CalculateAverageSpeed : MonoBehaviour
{
    public static CalculateAverageSpeed instance;
    public TMP_Text deathPanelText;
    public TMP_Text pausePanelText;
    public TMP_Text timeTxT;
    public int charsPerMinute;
    
    private float time;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start() => time = 0;

    private void Update()
    {
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timeTxT.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        deathPanelText.text = charsPerMinute.ToString();
        pausePanelText.text = charsPerMinute.ToString();
    }
}
