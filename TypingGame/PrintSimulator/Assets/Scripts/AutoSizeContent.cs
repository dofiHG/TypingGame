using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoSizeContent : MonoBehaviour
{
    public TMP_Text textComponent;
    public RectTransform contentRectTransform;

    void Start()
    {
        UpdateContentSize();
    }

    void UpdateContentSize()
    {
        textComponent.ForceMeshUpdate();
        var textSize = textComponent.GetRenderedValues(true);

        contentRectTransform.sizeDelta = new Vector2(textSize.x, contentRectTransform.sizeDelta.y);
    }
}
