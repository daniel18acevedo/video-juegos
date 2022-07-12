using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [Header("Pause menu")]
    [SerializeField] private GameObject _menuOptions;
    [SerializeField] private GameObject _controlsMenu;

    private void Start()
    {
        this._controlsMenu.SetActive(false);   
    }
    
    public void Controls()
    {
        this._menuOptions.SetActive(false);
        this._controlsMenu.SetActive(true);
    }

    public void Back()
    {
        this._menuOptions.SetActive(true);
        this._controlsMenu.SetActive(false);
    }
}
