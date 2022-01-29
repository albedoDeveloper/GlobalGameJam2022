using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostMenu : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;

    [SerializeField] GameObject _hostMenu;

    [SerializeField] Scene _RobGameScene;

    public void Return()
    {
        _hostMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_RobGameScene.buildIndex);
    }
}
