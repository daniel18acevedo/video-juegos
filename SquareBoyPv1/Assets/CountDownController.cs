using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownController : MonoBehaviour
{
    private static float currentTime = 0f;
    public TMP_Text countDownText;

    public void IncreaseCountDown(){
        currentTime += 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");
    }

    public void ResetTime(){
        currentTime = 0f;
    }

    public static string GetTime(){
        return currentTime.ToString("0");
    }
}
