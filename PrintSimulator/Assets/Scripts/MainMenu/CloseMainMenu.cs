using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMainMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void CloseMenu() => mainMenu.SetActive(false);
}
