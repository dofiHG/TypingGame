using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanelBtns : MonoBehaviour
{
    public GameObject mainMenu;
    public void ToMenu()
    {
        GameObject.Find("DeathPanel").SetActive(false);
        GameObject.Find("GameElements").SetActive(false);
        GameObject.Find("Player").SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
