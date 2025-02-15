using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGame : MonoBehaviour
{
    [SerializeField] private Image _penguin;
    [SerializeField] private Sprite[] _penguins;

    private int _language;
    private float _speed;

    private void Start()
    {
        LevelSetup();
    }

    private void LevelSetup()
    {
        _penguin.sprite = _penguins[StartGame.instance.penguinInt];
        _speed = StartGame.instance.speed * 0.6f;
        PenguinMover.instance.speed = _speed;
    }
}
