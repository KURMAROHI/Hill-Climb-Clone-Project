using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void OnStartButtonClick(Transform Thistransform)
    {
        Debug.Log("==>Start Button Click");
        SceneManager.LoadScene(1);
    }
}
