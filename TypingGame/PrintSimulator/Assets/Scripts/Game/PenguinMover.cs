using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMover : MonoBehaviour
{
    private const float _startPosition = -650f;

    private void Update()
    {
        if (TextGenerator.instance.currentCharIndex != 0)
        {
            float currentIndex = TextGenerator.instance.currentCharIndex;
            float textLength = TextGenerator.instance.currentPublicText.Length;
            transform.localPosition = new Vector2(_startPosition + currentIndex / textLength * 1380, transform.localPosition.y);
        }
    }
}
