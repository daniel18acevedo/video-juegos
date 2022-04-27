using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishSceneController : MonoBehaviour
{
    public TMP_Text countDownText;

    public void Start(){
        countDownText.text = CountDownController.GetTime();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}
