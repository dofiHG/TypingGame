using UnityEngine;
using UnityEngine.UI;

public class IceMoverUp : MonoBehaviour
{
    [HideInInspector] public float steps;

    private int _stepCounter;

    private void Start()
    {
        steps = TextGenerator.instance.currentPublicText.Length / 5;
    }

    public void Move()
    {
        _stepCounter++;
        if (_stepCounter != steps)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + 290f / steps);
            return;
        }

        transform.localPosition = new Vector2(transform.localPosition.x, -110);
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        enabled = false;
    }
}
