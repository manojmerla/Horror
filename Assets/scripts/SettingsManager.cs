using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;
    public GameObject settingsPanel;
    public MusicManager musicManager;

    private void Start()
    {
        // Load saved values
        musicToggle.isOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        sfxToggle.isOn = PlayerPrefs.GetInt("SFXOn", 1) == 1;

        musicToggle.onValueChanged.AddListener(ToggleMusic);
        sfxToggle.onValueChanged.AddListener(ToggleSFX);

        ApplySettings();
        settingsPanel.SetActive(false);
    }

    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    private void ToggleMusic(bool isOn)
    {
        PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);

        if (musicManager != null)
        {
            if (isOn)
                musicManager.musicSource.Play();
            else
                musicManager.musicSource.Pause();
        }
    }

    private void ToggleSFX(bool isOn)
    {
        PlayerPrefs.SetInt("SFXOn", isOn ? 1 : 0);
    }

    private void ApplySettings()
    {
        ToggleMusic(musicToggle.isOn);
        ToggleSFX(sfxToggle.isOn);
    }

    public void OnBackButtonPressed()
    {
        settingsPanel.SetActive(false);
    }
}
