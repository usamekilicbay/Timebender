using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScoreManager : MonoBehaviour
{
    private static SaveScoreManager _instance;
    public static SaveScoreManager Instance { get { return _instance; } }

    MenuUIManager menuUIManager;

    public int highScore;

    private void Awake() { _instance = this; highScore = PlayerPrefs.GetInt("HighScore"); }

    private void Start()
    {
        menuUIManager = MenuUIManager.Instance;
    }

    public void SaveScore(int comingScore)
    {
        highScore = PlayerPrefs.GetInt("HighScore");

        if (!PlayerPrefs.HasKey("HighScore") || highScore < comingScore)
        {
            PlayerPrefs.SetInt("HighScore", comingScore);
   
            if (comingScore != 0)
            { menuUIManager.isLose = false; }
            else { menuUIManager.isLose = true; }
        }
        else if (highScore >= comingScore)
        {
            menuUIManager.isLose = true;
        }
    }
}
