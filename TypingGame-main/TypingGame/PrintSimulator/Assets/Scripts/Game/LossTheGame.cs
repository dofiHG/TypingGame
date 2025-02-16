using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossTheGame : MonoBehaviour
{
    [SerializeField] private GameObject _lossPanel;
    [SerializeField] private GameObject _gameElements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _lossPanel.SetActive(true);
            _gameElements.SetActive(false);

            CalculateStates.instance.ShowStates();
        }
    }
}
