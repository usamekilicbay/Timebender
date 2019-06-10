using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    private static GameUIManager _instance;
    public static GameUIManager Instance { get { return _instance; } }

    public GameObject goalObject;
    public GameObject failedObject;

    private void Awake() { _instance = this; }


    public void GoalUI() { goalObject.SetActive(true); failedObject.SetActive(false); StartCoroutine(CloseObject(goalObject)); }

    public void FailedUI() { goalObject.SetActive(false); failedObject.SetActive(true); StartCoroutine(CloseObject(failedObject)); }

    IEnumerator CloseObject(GameObject willBeClosed) { yield return new WaitForSeconds(1); willBeClosed.SetActive(false); }
}
