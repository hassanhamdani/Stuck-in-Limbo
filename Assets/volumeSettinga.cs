using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettinga : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("volume", 0.5f); // Load the saved volume from PlayerPrefs
        volumeSlider.value = savedVolume; // Set the slider to the saved volume
        SetVolume(savedVolume); // Set the initial volume
    }

    public void SetVolume(float volume)
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>(); // Find all AudioSources in the scene
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume; // Set the volume of each AudioSource to the slider value
        }
        PlayerPrefs.SetFloat("volume", volume); // Save the volume to PlayerPrefs
    }
}
