using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CheckSpeed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PausePanelActiv.instance.OpenPausePanel();
        PausePanelActiv.instance.pausePanel.transform.Find("MainText").GetComponent<TMP_Text>().text = 
                                                                    "Вот это скорость! Повысим сложность?";
    }
}
