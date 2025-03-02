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
    private float[] _positions;
    public int _currentIndex = 1;

    private void Start()
    {
        _positions = new float[(int)_penguinsCount + 2];
        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] = i / (float)(_positions.Length - 1);
        }

        scrollRect.horizontalNormalizedPosition = _positions[_currentIndex];

        _nextPenguin.onClick.AddListener(OnNextImage);
        _prevPenguin.onClick.AddListener(OnPrevImage);
    }

    public void OnNextImage()
    {
        _currentIndex++;
        if (_currentIndex >= _positions.Length - 1)
        {
            StartCoroutine(ScrollToPosition(_positions[_positions.Length - 1], () =>
            {
                scrollRect.horizontalNormalizedPosition = _positions[1];
                _currentIndex = 1;
            }));
        }
        else
        {
            StartCoroutine(ScrollToPosition(_positions[_currentIndex]));
        }
    }

    public void OnPrevImage()
    {
        _currentIndex--;
        if (_currentIndex <= 0)
        {
            StartCoroutine(ScrollToPosition(_positions[0], () =>
            {
                scrollRect.horizontalNormalizedPosition = _positions[_positions.Length - 2];
                _currentIndex = _positions.Length - 2;
            }));
        }
        else
        {
            StartCoroutine(ScrollToPosition(_positions[_currentIndex]));
        }
    }

    private IEnumerator ScrollToPosition(float targetPosition, System.Action onComplete = null)
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
        onComplete?.Invoke();
    }

    private int GetRealIndex(int carouselIndex)
    {
        if (carouselIndex == 1 || carouselIndex == 4)
            return 0;
        else if (carouselIndex == 2)
            return 1;
        return 2;
    }

    public int GetCurrentRealIndex() => GetRealIndex(_currentIndex);
}
