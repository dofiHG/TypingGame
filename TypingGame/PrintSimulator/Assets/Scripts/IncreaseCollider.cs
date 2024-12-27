using UnityEngine;

public class IncreaseCollider : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector2(39.90432f, 14.2f);
    }

    public void IncreaseColl(float width)
    {
        transform.localScale = new Vector2(transform.localScale.x + width*2f, 14.2f);
    }
}
