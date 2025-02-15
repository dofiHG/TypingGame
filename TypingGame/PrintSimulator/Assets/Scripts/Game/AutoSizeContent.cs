using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoSizeContent : MonoBehaviour
{
    private TMP_Text textComponent;
    public RectTransform contentRectTransform;

    void Update()
    {
        UpdateContentSize();
    }

    private void UpdateContentSize()
    {
        textComponent = GameObject.Find("MainText").GetComponent<TMP_Text>();
        textComponent.ForceMeshUpdate();
        var textSize = textComponent.GetRenderedValues(true);

        contentRectTransform.sizeDelta = new Vector2(textSize.x, contentRectTransform.sizeDelta.y);
    }
}
