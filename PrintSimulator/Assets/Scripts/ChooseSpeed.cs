using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseSpeed : MonoBehaviour
{
    public static ChooseSpeed instance;
    public float speed;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void ChooseSpeedLvL()
    {
        foreach (Transform child in GameObject.Find("SpeedPanel").transform)
            child.GetComponent<Image>().color = new Color32(191, 191, 191, 255);
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.white;

        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "LightSpeed": speed = 0.4f; break;
            case "MediumSpeed": speed = 0.7f; break;
            case "HardSpeed": speed = 1f; break;
            case "VeryHardSpeed": speed = 1.4f; break;
        }
    }
}
