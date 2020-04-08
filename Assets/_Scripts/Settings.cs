using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/**
 *  Control the volume settings of the game.
 */
public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider, gameSlider;

    public void Start()
    {
        // Set player settings
        SetMusic(PlayerPrefs.GetFloat("music"));
        SetVolume(PlayerPrefs.GetFloat("game"));
    }

    /**
     * Set the music volume.
     */
    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        PlayerPrefs.SetFloat("music", volume);
        PlayerPrefs.Save();
    }

    /**
     * Set the game volume.
     */
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("gameVolume", volume);
        PlayerPrefs.SetFloat("game", volume);
        PlayerPrefs.Save();
    }

    /**
     * Load player settings.
     */
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music");
        gameSlider.value = PlayerPrefs.GetFloat("game");
    }
}
