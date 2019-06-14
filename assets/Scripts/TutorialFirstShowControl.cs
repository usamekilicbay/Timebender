using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFirstShowControl : MonoBehaviour
{
    public GameObject tutorialPanel;

    void Start()
    {
        if (!PlayerPrefs.HasKey("TutorialShowed"))
        {
            tutorialPanel.SetActive(true);
            PlayerPrefs.SetInt("TutorialShowed", 1);
            PlayerPrefs.DeleteAll();
        }
    }
}
