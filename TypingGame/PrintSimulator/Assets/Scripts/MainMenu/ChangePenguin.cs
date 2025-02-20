using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePenguin : MonoBehaviour
{
    [SerializeField] private Button _nextPenguin;
    [SerializeField] private Button _prevPenguin;
    [SerializeField] private Scrollbar _penguinsScroll;
    [SerializeField] private ScrollRect scrollRect;

    private const float _penguinsCount = 3;

    [HideInInspector] public int currentIndex = 0;

    private void Start()
    {
        _penguinsScroll.value = 0;
        _nextPenguin.onClick.AddListener(OnNextImage);
        _prevPenguin.onClick.AddListener(OnPrevImage);
    }

    public void OnNextImage()
    {
        if (currentIndex < _penguinsCount - 1)
        {
            currentIndex++;
            ScrollToImage(currentIndex);
        }
    }

    public void OnPrevImage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ScrollToImage(currentIndex);
        }
    }

    private void ScrollToImage(int index)
    {
        float targetPosition = index / (float)(_penguinsCount - 1);
        StartCoroutine(ScrollToPosition(targetPosition));
    }

    private IEnumerator ScrollToPosition(float targetPosition)
    {
        float startPosition = scrollRect.horizontalNormalizedPosition;
        float elapsedTime = 0.0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(startPosition, targetPosition, elapsedTime / duration);
            yield return null;
        }

        scrollRect.horizontalNormalizedPosition = targetPosition;
    }
}
