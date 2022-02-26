using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = 1f;

    private void Start()
    {
        volumeTextValue.text = PlayerPrefs.GetFloat("masterVolume").ToString("0.0");
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }

    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void Apply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }


    public void ResetButton()
    {
        AudioListener.volume = defaultVolume;
        volumeSlider.value = defaultVolume;
        volumeTextValue.text = defaultVolume.ToString("0.0");

        Apply();
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("NameSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
