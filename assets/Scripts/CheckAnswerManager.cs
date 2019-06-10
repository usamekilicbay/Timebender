using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
//[assembly:Preserve]// evet ama bu unity 
public class CheckAnswerManager : MonoBehaviour
{
    private static CheckAnswerManager _instance;
    public static CheckAnswerManager Instance { get { return _instance; } }


    GameUIManager gameUIManager;
    MenuUIManager menuUIManager;
    SaveScoreManager saveScoreManager;
    ScoreManager scoreManager;
    SoundManager soundManager;
    TimeManager timeManager;

    public Button button;

    public Sprite pauseIcon;
    public Sprite resumeIcon;

    public float correctRange;
    public float pointCount;
    public float count;

    public int pauseOrResume;

    private void Awake() { _instance = this; }

    // [Preserve]
    private void Start()
    {
        gameUIManager = GameUIManager.Instance;
        menuUIManager = MenuUIManager.Instance;
        saveScoreManager = SaveScoreManager.Instance;
        scoreManager = GetComponent<ScoreManager>();
        soundManager = SoundManager.Instance;
        timeManager = GetComponent<TimeManager>();
    }
    //[Preserve]
    public void StopTime()
    {
        pauseOrResume++;

        if (pauseOrResume == 1)
        {
            if (timeManager.miliSecond <= correctRange)
            {
                button.image.sprite = resumeIcon;
                timeManager.isResume = false;
                pointCount++;
                scoreManager.Score();
                gameUIManager.GoalUI();
                soundManager.ScoreSound();
                if (PlayerPrefs.GetInt("Vibration") == 1) Handheld.Vibrate();
                if (pointCount >= count) { pointCount = 0; correctRange -= 10; }
               // Time.timeScale = 0;
            }

            else if (timeManager.miliSecond > correctRange)
            {               
                timeManager.isResume = false;
                pauseOrResume = 0;
               // Time.timeScale = 0;
                gameUIManager.FailedUI();
                saveScoreManager.SaveScore(scoreManager.score);
                menuUIManager.GameOver();
                soundManager.GameOverSound();
                if (PlayerPrefs.GetInt("Vibration") == 1) Handheld.Vibrate();
            }
        }
        else if (pauseOrResume == 2)
        {
            button.image.sprite = pauseIcon;
            WaitArea();
        }
    }


    void WaitArea()
    {
        timeManager.isResume = true;
        //Time.timeScale = 1;
        pauseOrResume = 0;
    }

   // [Preserve]
    public void ResetCountRange() { pointCount = 0; count = 10; correctRange = 70; }
}
