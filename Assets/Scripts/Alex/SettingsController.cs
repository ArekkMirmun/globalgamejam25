using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public AudioMixer sfxMixer;
    public AudioMixer bgmMixer;
    public MenuController menuController;
    public WinController winController;
    public GameObject settingsPanel;
    public GameObject lifeCanvas;
    public GameObject oxygenCanvas;
    public PlayerMovement playerMovement;
    public Button resumeButton;
    public TMP_Dropdown resolutionDropdown; // Assign this in the Inspector
    public TMP_Dropdown refreshRateDropdown; // Assign this in the Inspector
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions = new List<Resolution>();
    private int selectedResolutionIndex = 0;

    private void Start()
    {
        resolutions = Screen.resolutions; // Get all supported resolutions
        PopulateResolutionDropdown();
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        var resolutionOptions = new List<string>();

        // Filter resolutions based on height >= 720
        foreach (var res in resolutions)
        {
            if (res.height >= 720) // Only resolutions >= 720p
            {
                string resolutionOption = $"{res.width} x {res.height}";

                if (!resolutionOptions.Contains(resolutionOption))
                {
                    resolutionOptions.Add(resolutionOption);
                    filteredResolutions.Add(res);
                }

                // Track current resolution
                if (res.width == Screen.currentResolution.width &&
                    res.height == Screen.currentResolution.height)
                {
                    selectedResolutionIndex = resolutionOptions.Count - 1;
                }
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = selectedResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Populate refresh rate dropdown for the selected resolution
        PopulateRefreshRateDropdown(filteredResolutions[selectedResolutionIndex]);
    }

    private void PopulateRefreshRateDropdown(Resolution resolution)
    {
        refreshRateDropdown.ClearOptions();
        var refreshRateOptions = new List<string>();
        var refreshRates = new HashSet<int>();

        foreach (var res in resolutions)
        {
            if (res.width == resolution.width && res.height == resolution.height)
            {
                if (!refreshRates.Contains(res.refreshRate))
                {
                    refreshRates.Add(res.refreshRate);
                    refreshRateOptions.Add($"{res.refreshRate} Hz");
                }
            }
        }

        // Set current refresh rate
        int currentRefreshRateIndex = 0;
        for (int i = 0; i < refreshRateOptions.Count; i++)
        {
            if (int.Parse(refreshRateOptions[i].Replace(" Hz", "")) == Screen.currentResolution.refreshRate)
            {
                currentRefreshRateIndex = i;
                break;
            }
        }

        refreshRateDropdown.AddOptions(refreshRateOptions);
        refreshRateDropdown.value = currentRefreshRateIndex;
        refreshRateDropdown.RefreshShownValue();
    }

    public void OnResolutionChanged(int resolutionIndex)
    {
        selectedResolutionIndex = resolutionIndex;
        PopulateRefreshRateDropdown(filteredResolutions[resolutionIndex]);
        ApplySettings();
    }

    public void OnRefreshRateChanged(int refreshRateIndex)
    {
        ApplySettings();
    }

    private void ApplySettings()
    {
        var selectedResolution = filteredResolutions[selectedResolutionIndex];
        int selectedRefreshRate = int.Parse(refreshRateDropdown.options[refreshRateDropdown.value].text.Replace(" Hz", ""));

        // Find matching resolution from Screen.resolutions
        foreach (var res in resolutions)
        {
            if (res.width == selectedResolution.width &&
                res.height == selectedResolution.height &&
                res.refreshRate == selectedRefreshRate)
            {
                Screen.SetResolution(res.width, res.height, Screen.fullScreen, res.refreshRate);
                Debug.Log($"Applied resolution: {res.width}x{res.height} @ {res.refreshRate}Hz");
                return;
            }
        }
    }

    public void HideSettings()
    {
        
        lifeCanvas.SetActive(true);
        oxygenCanvas.SetActive(true);
        
        settingsPanel.SetActive(false);
        playerMovement.UnFreezeMovement();
    }

    public void ShowSettings()
    {
        if (menuController.IsMenuOpen() || winController.IsMenuOpen()) return;

        lifeCanvas.SetActive(false);
        oxygenCanvas.SetActive(false);
        
        settingsPanel.SetActive(true);
        playerMovement.FreezeMovement();
        resumeButton.Select();
    }

    public void SetVolumeSfx(float volume)
    {
        sfxMixer.SetFloat("Volume", volume);
    }

    public void SetVolumeBGM(float volume)
    {
        bgmMixer.SetFloat("Volume", volume);
    }

    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    
    public void ToggleSettings()
    {
        if (settingsPanel.activeSelf)
        {
            HideSettings();
        }
        else
        {
            ShowSettings();
        }
    }
}
