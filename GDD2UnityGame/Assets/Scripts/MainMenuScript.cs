using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    /* Main Menu Code */
    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Game");
    }

    public void LevelSelect()
    {
        Debug.Log("Level Select");
        SceneManager.LoadScene("LevelSelect");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    /* Settings Menu Code */
    public AudioMixer aMixer;
    Resolution[] resolutions;

    void Awake()
    {
        resolutions = Screen.resolutions;
    }

    // run when options is enabled to initialize menu values
    public void OnOptions()
    {
        // get all variables to adjust
        TMP_Dropdown resolutionDropdownObject = GameObject.Find("ResolutionDropdown").GetComponent<TMP_Dropdown>();
        Toggle fullscreenToggleObject = GameObject.Find("FullscreenToggle").GetComponent<Toggle>();
        TMP_Dropdown qualityObject = GameObject.Find("GraphicsQualityDropdown").GetComponent<TMP_Dropdown>();
        Slider volumeSliderObject = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        // set default volume to 30 before checking to get volume
        float vol = -30;
        aMixer.GetFloat("volume", out vol);

        // fill in resolution dropdown
        resolutionDropdownObject.ClearOptions();
        List<string> resOptions = new List<string>();
        int currentRes = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentRes = i;
        }
        resolutionDropdownObject.AddOptions(resOptions);

        // adjust menu items accordingly
        resolutionDropdownObject.value = currentRes;
        fullscreenToggleObject.isOn = Screen.fullScreen;
        qualityObject.value = QualitySettings.GetQualityLevel();
        volumeSliderObject.value = vol;
    }

    public void SetVolume(float vol)
    {
        Debug.Log(vol);
        aMixer.SetFloat("volume", vol);

        if (vol == -40) // turn off the music if volume slider is at bottom
            aMixer.SetFloat("volume", -80);

        // I set the volume slider to go from -40 to 0 instead of -80 to 0 so the user could have a bit 
        // more precise control over the volume
    }

    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}