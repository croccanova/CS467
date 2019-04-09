using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour
{
    public Slider MasterVolumeSlider,
                  MusicVolumeSlider,
                  VertSensitivitySlider,
                  HorizSensitivitySlider,
                  AIShootingSlider;

    public Button saveButton;

    public Slider[] settingSliders;
    public string[] prefs = new string[] {
            "master_vol",
            "music_vol",
            "v_sensitivity",
            "h_sensitivity",
            "ai_shot_variance"
        };

    void Start()
    {
        settingSliders = new Slider[] {
            MasterVolumeSlider,
            MusicVolumeSlider,
            VertSensitivitySlider,
            HorizSensitivitySlider,
            AIShootingSlider
        };

        for (int i = 0; i < settingSliders.Length; i++)
        {
            if (PlayerPrefs.HasKey(prefs[i]))
            {
                settingSliders[i].value = PlayerPrefs.GetFloat(prefs[i]);
            }
        }

        saveButton.onClick.AddListener(SaveSettings);
    }

    void SaveSettings()
    {
        AudioListener.volume = MasterVolumeSlider.value;
        GameObject.Find("Audio Management").GetComponent<AudioSource>().volume = MusicVolumeSlider.value;

        for (int i = 0; i < settingSliders.Length; i++)
        {
            PlayerPrefs.SetFloat(prefs[i], settingSliders[i].value);
        }
    }
}
