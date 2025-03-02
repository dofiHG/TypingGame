using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationBtns : MonoBehaviour
{
    [SerializeField] private Button _retryBtn;
    [SerializeField] private Button _menuBtn;

    private void Start()
    {
        _retryBtn.onClick.AddListener(Retry);
        _menuBtn.onClick.AddListener(Menu);
    }

    private void Retry() => SceneManager.LoadScene(1);

    private void Menu() => SceneManager.LoadScene(0);
}
