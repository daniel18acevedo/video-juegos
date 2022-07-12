using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsController : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider _audioSlider;
    private float _sliderValue;
    [SerializeField] private Image _muteImage;

    // Start is called before the first frame update
    void Start()
    {
        this._audioSlider.value = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = this._audioSlider.value;
        this.CheckIfIsMuted();
    }

    public void ChangeSlider(float value)
    {
        this._sliderValue = value;
        PlayerPrefs.SetFloat("audioVolume", value);
        AudioListener.volume = this._audioSlider.value;
        this.CheckIfIsMuted();
    }

    private void CheckIfIsMuted()
    {
        this._muteImage.enabled = this._sliderValue == 0;
    }
}
