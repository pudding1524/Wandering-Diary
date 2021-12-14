using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bag_switch : MonoBehaviour
{
    public GameObject bag;
    //public GameObject Bag_Canvas;
    public GameObject _select; 
    [SerializeField] private bool canvas_bool;
    [SerializeField] private Button button;

    private void Start()
    {
        //_select.GetComponent<Button>().Select();
    }
    void Update()
    {
        Canvas_Open();
    }

    private void Canvas_Open()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas_bool = !canvas_bool;
            bag.SetActive(canvas_bool);
            //button = bag.transform.GetChild(0).GetComponent<Button>();
            //button.Select();
        }
    }
}
