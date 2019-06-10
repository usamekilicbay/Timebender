using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    private static LanguageManager _intance;
    public static LanguageManager Instance { get { return _intance; } }

    public GameObject enButton;
    public GameObject trButton;

    public GameObject tutorialEN;
    public GameObject tutorialTR;

    void Awake()
    {
        _intance = this;

        if (!PlayerPrefs.HasKey("LanguageCode"))
        {
            enButton.SetActive(true); trButton.SetActive(false); tutorialEN.SetActive(true); tutorialTR.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("LanguageCode") == 0)
            {
                enButton.SetActive(true); trButton.SetActive(false); tutorialEN.SetActive(true); tutorialTR.SetActive(false);
            }
            else
            {
                enButton.SetActive(false); trButton.SetActive(true); tutorialEN.SetActive(false); tutorialTR.SetActive(true);
            }

        }
      
    }


    public void ENLanguage()
    {
        enButton.SetActive(true); trButton.SetActive(false);
        PlayerPrefs.SetInt("LanguageCode", 0);
        tutorialEN.SetActive(true); tutorialTR.SetActive(false);
    }


    public void TRLanguage()
    {
        enButton.SetActive(false); trButton.SetActive(true);
        PlayerPrefs.SetInt("LanguageCode", 1);
        tutorialEN.SetActive(false); tutorialTR.SetActive(true);
    }
}
