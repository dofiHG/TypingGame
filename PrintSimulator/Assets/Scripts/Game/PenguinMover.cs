using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMover : MonoBehaviour
{
    public static PenguinMover instance;

    private const float _startPosition = -650f;
    private const float _distance = 1300f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void MovePenguin(float textLength)
    {
        float step = _distance / textLength;

        float newX = transform.localPosition.x + step;
        transform.localPosition = new Vector2(newX, transform.localPosition.y);
    }
}
