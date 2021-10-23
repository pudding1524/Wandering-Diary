using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Start_help : MonoBehaviour
{
    public GameObject diaolog;
    public GameObject talkUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        talkUI.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
