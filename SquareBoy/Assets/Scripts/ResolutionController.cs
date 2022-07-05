using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    [Header("FullSize")]
    [SerializeField] private Toggle _fullSizeToggle;

    [Header("Resolution")]
    [SerializeField] private TMP_Dropdown _resolutionDropDown;
    private Resolution[] _resolutions;

    // Start is called before the first frame update
    void Start()
    {
        this._fullSizeToggle.isOn = Screen.fullScreen;
        this.CheckResolution();
    }


    public void EnabledFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void CheckResolution()
    {
        this._resolutions = Screen.resolutions;
        this._resolutionDropDown.ClearOptions();
        var options = this._resolutions.Select(resolution => $"{resolution.width} x {resolution.height}");
        var actualResultionIndex = 0;
     
        if (Screen.fullScreen)
        {
            var actualResolution = this._resolutions.First(resolution => resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height);

            actualResultionIndex = this._resolutions.ToList().IndexOf(actualResolution);
        }

        this._resolutionDropDown.AddOptions(options.ToList());
        this._resolutionDropDown.value = actualResultionIndex;
        this._resolutionDropDown.RefreshShownValue();

        this._resolutionDropDown.value = PlayerPrefs.GetInt("resolutionNumber", 0);
    }

    public void ChangeResolution(int indexResolution)
    {
        PlayerPrefs.SetInt("resolutionNumber", this._resolutionDropDown.value);

        var resolution = this._resolutions[indexResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
