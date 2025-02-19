using UnityEngine;

public class IceMover : MonoBehaviour
{
    public static IceMover instance;
    [HideInInspector] public int steps;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Move()
    {
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + 290 / steps);

        if (transform.localPosition.y >= -110)
        {
            Debug.Log(1);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<IceMover>().enabled = false;
        }
    }

    private void Update() { }
}
