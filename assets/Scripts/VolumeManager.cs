using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    private static VolumeManager _instance;
    public static VolumeManager Instance { get { return _instance; } }

    public AudioSource musicSource;
    public AudioSource soundEffectSource;

    public GameObject musicOpenerButton;
    public GameObject musicCloserButton;
    public GameObject soundEffectOpenerButton;
    public GameObject soundEffectCloserButton;

    private void Awake()
    {
        _instance = this;

        if (!PlayerPrefs.HasKey("MusicVolume")) { musicSource.volume = 1f; musicOpenerButton.SetActive(false); musicCloserButton.SetActive(true); }
        else
        {
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");

            if (musicSource.volume == 1f)
            {
                musicOpenerButton.SetActive(false); musicCloserButton.SetActive(true);
            }
            else
            {
                musicOpenerButton.SetActive(true); musicCloserButton.SetActive(false);
            }
        }

        if (!PlayerPrefs.HasKey("SoundEffectVolume")) { soundEffectSource.volume = 1f; }
        else
        {
            soundEffectSource.volume = PlayerPrefs.GetFloat("SoundEffectVolume");

            if (soundEffectSource.volume == 1)
            {
                soundEffectOpenerButton.SetActive(false); soundEffectCloserButton.SetActive(true);
            }
            else
            {
                soundEffectOpenerButton.SetActive(true); soundEffectCloserButton.SetActive(false);
            }
        }
    }


    public void OpenMusic() { musicSource.volume = 1; PlayerPrefs.SetFloat("MusicVolume", 1); musicOpenerButton.SetActive(false); musicCloserButton.SetActive(true); }
    public void CloseMusic() { musicSource.volume = 0; PlayerPrefs.SetFloat("MusicVolume", 0); musicOpenerButton.SetActive(true); musicCloserButton.SetActive(false); }


    public void OpenSoundEffect() { soundEffectSource.volume = 1; PlayerPrefs.SetFloat("SoundEffectVolume", 1); soundEffectOpenerButton.SetActive(false); soundEffectCloserButton.SetActive(true); }
    public void CloseSoundEffect() { soundEffectSource.volume = 0; PlayerPrefs.SetFloat("SoundEffectVolume", 0); soundEffectOpenerButton.SetActive(true); soundEffectCloserButton.SetActive(false); }

}
