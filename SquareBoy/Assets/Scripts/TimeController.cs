using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [Header("For time")]
    [SerializeField] private TextMeshProUGUI _timeText;
    private float _currentTime;

    // Update is called once per frame
    void Update()
    {
        this._currentTime += 1*Time.deltaTime;
        this._timeText.text = this._currentTime.ToString("0");

        PlayerPrefs.SetString("time", this._currentTime.ToString("0"));
    }
}
