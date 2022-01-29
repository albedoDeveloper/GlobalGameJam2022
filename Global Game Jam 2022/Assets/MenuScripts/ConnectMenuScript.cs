using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectMenuScript : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _connectMenu;
    public void Return()
    {
        _connectMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
