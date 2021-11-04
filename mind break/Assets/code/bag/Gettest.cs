using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gettest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            all_object.Instance.vege();
        }
    }
}
