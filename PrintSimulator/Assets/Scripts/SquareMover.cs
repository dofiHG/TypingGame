using UnityEngine;

public class SquareMover : MonoBehaviour
{
    public float speed;
    public static SquareMover instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        speed = ChooseSpeed.instance.speed;
    }

    private void FixedUpdate() => transform.Translate(Vector2.right * speed * Time.deltaTime);
}
