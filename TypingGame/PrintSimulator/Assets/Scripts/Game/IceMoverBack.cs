using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMoverBack : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
    }
}
