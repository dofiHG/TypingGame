using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanelBtns : MonoBehaviour
{
    public void ToMenu() => SceneManager.LoadScene(0);

    public void PlayAgain()
    {
        //YandexGame.savesData.currentSpeed = CameraMover.instance.environmentSpeed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
