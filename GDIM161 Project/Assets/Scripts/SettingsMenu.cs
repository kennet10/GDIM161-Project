using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    Resolution[] resolutions;

    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;

    private void Start()
    {
        // Set default resolution, aspect ratio, and full-screen mode
        Resolution defaultResolution = new Resolution { width = 3840, height = 2160 };
        float defaultAspectRatio = 16f / 9f;
        bool defaultFullScreen = true;

        // Set resolution dropdown options
        resolutions = Screen.resolutions.Where(resolution => Mathf.Approximately((float)resolution.width / resolution.height, defaultAspectRatio)).ToArray();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == defaultResolution.width && resolutions[i].height == defaultResolution.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();

        // Set initial resolution and full-screen mode
        Screen.SetResolution(defaultResolution.width, defaultResolution.height, defaultFullScreen);
        Screen.fullScreen = defaultFullScreen;
    }

    /*public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }*/

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
