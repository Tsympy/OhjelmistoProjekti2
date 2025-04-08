using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource gameAudio;  // Assign this in the Inspector
    public Slider volumeSlider;   // Assign the UI Slider in the Inspector

    void Start()
    {
        // Load saved volume setting or set to 1 if not saved
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        volumeSlider.value = savedVolume;

        // Apply the saved volume
        SetVolume(savedVolume);

        // Add listener for runtime changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        if (gameAudio != null)
        {
            gameAudio.volume = volume;  // Update volume
        }

        // Save the volume setting
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
