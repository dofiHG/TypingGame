using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGame : MonoBehaviour
{
    [SerializeField] private Image _penguin;
    [SerializeField] private Sprite[] _penguins;

    [HideInInspector] public float speed;

    public void LevelSetup(int penguinInt, float speed)
    {
        _penguin.sprite = _penguins[penguinInt];
        _penguin.gameObject.GetComponent<Animator>().SetInteger("Penguin", penguinInt);
        this.speed = 3;
    }
}
