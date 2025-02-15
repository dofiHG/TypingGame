using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveMainText : MonoBehaviour
{
    public static MoveMainText instance;

    [SerializeField] private Scrollbar _textScroller;
    [SerializeField] private TMP_Text _mainText;

    private int _textLength;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        SetUp();
    }

   private void SetUp()
    {
        _textScroller.value = 0;
        _textLength = _mainText.text.Length;
    }

    public void MoveScroller()
    {
        _textScroller.value += (float)1 / _textLength;
    }
}
