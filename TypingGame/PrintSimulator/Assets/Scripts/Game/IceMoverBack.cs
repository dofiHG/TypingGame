using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMoverBack : MonoBehaviour
{
    private SetupGame _setupManager;
    private float _speed;

    private void Start()
    {
        _setupManager = GameObject.Find("LevelSetupManager").GetComponent<SetupGame>();
        _speed = _setupManager.speed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _speed);
    }
}
