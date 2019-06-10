using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    private static VibrationManager _instance;
    public static VibrationManager Instance{ get { return _instance; } }

    public int isVibrate;

    public GameObject vibrationOpenerButton;
    public GameObject vibrationCloserButton;

    void Awake()
    {
        _instance = this;

        if (!PlayerPrefs.HasKey("Vibration")) { isVibrate = 1; vibrationOpenerButton.SetActive(false); vibrationCloserButton.SetActive(true); }
        else
        {
            isVibrate = PlayerPrefs.GetInt("Vibration");
            if (isVibrate == 1)
            {
                vibrationOpenerButton.SetActive(false); vibrationCloserButton.SetActive(true);
            }
            else
            {
                vibrationOpenerButton.SetActive(true); vibrationCloserButton.SetActive(false);
            }
        }
    }

    public void OpenVibration()
    {
        isVibrate = 1;
        PlayerPrefs.SetInt("Vibration", 1);
        vibrationOpenerButton.SetActive(false); vibrationCloserButton.SetActive(true);
    }

    public void CloseVibration()
    {
        isVibrate = 0;
        PlayerPrefs.SetInt("Vibration", 0);
        vibrationOpenerButton.SetActive(true); vibrationCloserButton.SetActive(false);
    }
}
