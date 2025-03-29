using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject endPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        endPanel.SetActive(true);    
        GameObject.Find("PauseBtn").GetComponent<Button>().enabled = false;
        GameObject.Find("CalculateAverageSpeed").GetComponent<CalculateAverageSpeed>().enabled = false;
        GameObject.Find("PauseBtn").GetComponent<PausePanelActiv>().enabled = false;
    }
}
