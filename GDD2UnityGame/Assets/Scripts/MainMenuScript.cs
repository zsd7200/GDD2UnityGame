using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    /* Settings Menu Code */
    public AudioMixer aMixer;
    List<string> resOptions;

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
        Resolution[] resolutions = Screen.resolutions;
        resOptions = new List<string>();
        string screenRes = Screen.width + " x " + Screen.height;

        // create strings for dropdown
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resOptions.Add(option);
        }

        // delete duplicates created in build mode
        for (int i = 0; i < resOptions.Count; i++)
            for (int j = 0; j < resOptions.Count; j++)
                if (resOptions[i] == resOptions[j] && i != j)
                    resOptions.Remove(resOptions[i]);  

        // clear list
        resolutionDropdownObject.ClearOptions();

        // re-fill
        resolutionDropdownObject.AddOptions(resOptions);

        // adjust menu items accordingly
        for (int i = 0; i < resOptions.Count; i++)
            if (screenRes == resOptions[i])
                resolutionDropdownObject.value = i;

        fullscreenToggleObject.isOn = Screen.fullScreen;
        qualityObject.value = QualitySettings.GetQualityLevel();
        volumeSliderObject.value = vol;
    }

    public void SetVolume(float vol)
    {
        // "volume" is an "exposed parameter" in the audio mixer that allows for the volume to be changed
        aMixer.SetFloat("volume", vol);

        if (vol == -40) // turn off the music if volume slider is at bottom
            aMixer.SetFloat("volume", -80);

        // I set the volume slider to go from -40 to 0 instead of -80 to 0 so the user could have a bit 
        // more precise control over the volume
    }

    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual, true);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resIndex)
    {
        int width;
        int height;

        string[] option = resOptions[resIndex].Split(' ');

        int.TryParse(option[0], out width);
        int.TryParse(option[2], out height);

        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}