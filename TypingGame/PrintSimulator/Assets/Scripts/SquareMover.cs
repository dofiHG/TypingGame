using UnityEngine;
using YG;

public class SquareMover : MonoBehaviour
{
    public float speed;
    public static SquareMover instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        speed = YandexGame.savesData.currentSpeed;
    }

    private void FixedUpdate() => transform.Translate(Vector2.right * speed * Time.deltaTime);
}
