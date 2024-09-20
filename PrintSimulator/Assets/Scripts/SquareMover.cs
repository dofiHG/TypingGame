using UnityEngine;

public class SquareMover : MonoBehaviour
{
    public float speed;

    private void FixedUpdate() => transform.Translate(Vector2.right * speed * Time.deltaTime);
}
