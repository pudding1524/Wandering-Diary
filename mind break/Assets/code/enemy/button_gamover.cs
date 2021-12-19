using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_gamover : MonoBehaviour
{
    public void GameOver_button(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
        Time.timeScale = 1.0f;
    }
}
