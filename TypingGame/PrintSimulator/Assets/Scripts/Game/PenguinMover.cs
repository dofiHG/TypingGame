using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMover : MonoBehaviour
{
    public static PenguinMover instance;

    [HideInInspector] public float speed;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        Debug.Log(speed);
    }

    private void FixedUpdate() => transform.Translate(Vector2.right * speed * Time.deltaTime);
}
