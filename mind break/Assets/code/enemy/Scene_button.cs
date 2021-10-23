using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_button : MonoBehaviour
{
    public void BottonMoveScene(string game)
    {
        SceneManager.LoadScene(game);
        Time.timeScale = 1.0f;
    }
}
