using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Light_Switch : MonoBehaviour
{

    [Header("時間")]
    public Image Time_Line;

    [Header("圖片")]
    public Sprite sunny, raining, night;

    public static Light_Switch Instance;
    
    [SerializeField] public Light2D Into_Night;

    private void Awake()
    {
        Instance = this;
        Time_Line.sprite = sunny;
    }

    public void Light_Night()
    {
        Into_Night.intensity = 0.5f;
        Time_Line.sprite = night;
    }
}