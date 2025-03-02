using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMoverBack : MonoBehaviour
{
    private SetupGame _setupManager;
    public float speed;

    private void Start()
    {
        _setupManager = GameObject.Find("LevelSetupManager").GetComponent<SetupGame>();
        speed = _setupManager.speed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed, Space.Self);
    }
}
