using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Detect : MonoBehaviour
{
    public GameObject Detect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("123");
            GhostChase.Instance.Speed_Change_Up();
        }   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GhostChase.Instance.Speed_normal();
        }
    }
}
