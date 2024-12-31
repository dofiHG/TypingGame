using UnityEngine;
using UnityEngine.UI;
using YG;

public class SquareMover : MonoBehaviour
{
    public float speed;
    public static SquareMover instance;
    public Sprite[] sprites;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        speed = YandexGame.savesData.currentSpeed;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[StartGame.instance.characterInt];
    }

    private void FixedUpdate() => transform.Translate(Vector2.right * speed * Time.deltaTime);
}
