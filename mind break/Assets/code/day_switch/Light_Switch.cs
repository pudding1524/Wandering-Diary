using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light_Switch : MonoBehaviour
{

    [SerializeField] private Light2D Into_Night;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Into_Night.intensity = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Into_Night.intensity = 0.5f;
        }
    }

    private void Light_Trigger()
    {
        //Into_Night.intensity = 0.5f;
    }
}