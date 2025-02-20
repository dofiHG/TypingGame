using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIce : MonoBehaviour
{
    [SerializeField] private GameObject _icePrefab;
    [SerializeField] private GameObject _parent;

    private void SpawnNewIce(int targetPosition)
    {
        GameObject newIce = Instantiate(_icePrefab, _parent.transform);
        newIce.transform.localPosition = new Vector2(targetPosition, newIce.transform.position.y);
    }
}
