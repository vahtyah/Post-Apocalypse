using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider, sfxSlider;
    private float musicVolume, sfxVolume;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
        musicSlider.onValueChanged.AddListener(MusicSliderOnValueChanged);
        sfxSlider.onValueChanged.AddListener(SFXSliderOnValueChanged);
    }

    private void MusicSliderOnValueChanged(float value)
    {
        musicVolume = value;
        audioManager.SetMusicVolume(musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    private void SFXSliderOnValueChanged(float value)
    {
        sfxVolume = value;
        audioManager.SetSFXVolume(sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }
}