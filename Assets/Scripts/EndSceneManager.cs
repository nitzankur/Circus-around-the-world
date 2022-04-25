using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.TakenAnimals = 0;
            SceneManager.LoadSceneAsync("Openning");
        }
    }
}
