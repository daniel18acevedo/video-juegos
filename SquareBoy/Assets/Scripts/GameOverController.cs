using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [Header("For melons")]
    [SerializeField] private TextMeshProUGUI _melonsText;

    [Header("For time")]
    [SerializeField] private TextMeshProUGUI _timeText;

    private void Start()
    {
        this._melonsText.text = $"{PlayerStats.TotalMelons}";

        var timeAccount = PlayerPrefs.GetString("time", "00");
        this._timeText.text = timeAccount;

        var audioVolume = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = audioVolume;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene((int)Scenes.StartMenu);
    }
}
