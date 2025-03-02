using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGame : MonoBehaviour
{
    [SerializeField] private Image _penguin;
    [SerializeField] private Sprite[] _penguins;
    private int _language;

    [HideInInspector] public float speed;

    private void Awake()
    {
        LevelSetup();
    }

    private void LevelSetup()
    {
        _penguin.sprite = _penguins[StartGame.instance.penguinInt];
        _penguin.gameObject.GetComponent<Animator>().SetInteger("Penguin", StartGame.instance.penguinInt);
        switch (StartGame.instance.speed)
        {
            case 0: speed = 1f; break;
            case 1: speed = 3f; break;
            case 2: speed = 8f; break;
            case 3: speed = 14f; break;
            case 4: speed = 25f; break;
        }
    }
}
