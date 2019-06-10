using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }

    public TextMeshProUGUI scoreTextMeshProUGUI;

    public int score = 0;


    private void Awake() { _instance = this; }

    public void Score() { score++; scoreTextMeshProUGUI.SetText("X " + score); }

    public void ResetScore() { score = 0; scoreTextMeshProUGUI.SetText("X " + score); }
}
