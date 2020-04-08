using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider, gameSlider;

    public void Start()
    {
        SetMusic(PlayerPrefs.GetFloat("music"));
        SetVolume(PlayerPrefs.GetFloat("game"));
    }
    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        PlayerPrefs.SetFloat("music", volume);
        PlayerPrefs.Save();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("gameVolume", volume);
        PlayerPrefs.SetFloat("game", volume);
        PlayerPrefs.Save();
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music");
        gameSlider.value = PlayerPrefs.GetFloat("game");
    }
}
