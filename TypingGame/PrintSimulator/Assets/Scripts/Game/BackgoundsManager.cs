using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgoundsManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _backgounds;
     
    private void Awake()
    {
        gameObject.GetComponent<Image>().sprite = _backgounds[Random.Range(0, 6)]; 
    }
}
