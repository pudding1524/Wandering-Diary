using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class all_object : MonoBehaviour
{
    public static all_object Instance;
    public int soda;
    public int vegetable;

    int[] array = { 1, 2, 3 };
    private void Awake() 
    {
        Instance = this;
    }
    public void vege()
    {
        vegetable += 1;
    }

}
