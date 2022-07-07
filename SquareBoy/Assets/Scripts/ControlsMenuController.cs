using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenuController : MonoBehaviour
{
    
    public void BackToStartMenu()
    {
        SceneManager.LoadScene((int)Scenes.StartMenu);
    }
}
