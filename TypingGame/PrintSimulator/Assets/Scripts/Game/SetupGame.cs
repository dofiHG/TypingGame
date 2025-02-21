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
        speed = StartGame.instance.speed * 2f;
    }
}
