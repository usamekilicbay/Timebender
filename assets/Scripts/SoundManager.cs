using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    public AudioSource soundEffect;
    public AudioSource musicSource;

    public AudioClip buttonSound;
    public AudioClip scoreSound;
    public AudioClip gameOverSound;

    public AudioClip mainTheme;
    public AudioClip gameTheme;


    private void Awake() { _instance = this; }

    public void ButtonSound() { soundEffect.PlayOneShot(buttonSound); }
    public void ScoreSound() { soundEffect.PlayOneShot(scoreSound); }
    public void GameOverSound() { soundEffect.PlayOneShot(gameOverSound); }


    public void MainTheme() { musicSource.clip = mainTheme; }
    public void GameTheme() { musicSource.clip = gameTheme; }
}
