using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    private static MenuUIManager _instance;
    public static MenuUIManager Instance { get { return _instance; } }

    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject tutorialPanel;


    public GameObject highScoreImage;
    public GameObject loseImage;

    public TextMeshProUGUI highScoreTextPro;
    public TextMeshProUGUI gameOverScoreText;

    TimeManager timeManager;
    ScoreManager scoreManager;

    public bool isLose;

    private void Awake() { _instance = this; highScoreTextPro.SetText("X " + PlayerPrefs.GetInt("HighScore")); }

    private void Start() { timeManager = TimeManager.Instance; scoreManager = GetComponent<ScoreManager>(); }

    public void SetHighScoreText() { highScoreTextPro.SetText("X " + PlayerPrefs.GetInt("HighScore")); }

    public void Play()
    {
        timeManager.isResume = true;
        //SceneManager.LoadScene(0);
        gamePanel.SetActive(true);

        mainMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverScoreText.SetText("X " + scoreManager.score);
        gamePanel.SetActive(false);       
        if (isLose == false)
        {
            highScoreImage.SetActive(true);
            loseImage.SetActive(false);
        }
        else if (isLose == true)
        {
            highScoreImage.SetActive(false);
            loseImage.SetActive(true);
        }
        gameOverPanel.SetActive(true);
    }

    public void OpenMainMenuPanel()
    {
        //SceneManager.LoadScene(0);
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);
        settingsPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        //Time.timeScale = 1;
    }
   // public void CloseMainMenuPanel() { mainMenuPanel.SetActive(false); }

    public void OpenSettingsPanel() { settingsPanel.SetActive(true); mainMenuPanel.SetActive(false); }
   // public void CloseSettingsPanel() { settingsPanel.SetActive(false); mainMenuPanel.SetActive(true); }

    public void OpenTutorialPanel() { tutorialPanel.SetActive(true); mainMenuPanel.SetActive(false); }//gamePanel.SetActive(false); }
  //  public void CloseTutorialPanel() { tutorialPanel.SetActive(false); mainMenuPanel.SetActive(true); }
}
