using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _hostMenu;
    [SerializeField] GameObject _connectMenu;

    public void PlayGame()
    {
        _mainMenu.SetActive(false);
        _hostMenu.SetActive(true);
    }

    public void ConnectMenu()
    {
        _mainMenu.SetActive(false);
        _connectMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
