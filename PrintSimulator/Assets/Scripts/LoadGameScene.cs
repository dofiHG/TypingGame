using UnityEngine;
using YG;

public class LoadGameScene : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetInteger("Character", StartGame.instance.characterInt);
    }
}
