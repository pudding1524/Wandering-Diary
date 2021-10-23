using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class weather : MonoBehaviour
{

    [Header("天氣")]
    public Image Weather;

    [Header("圖片")]
    public Sprite sunny, raining, night;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Weather.sprite = sunny;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
