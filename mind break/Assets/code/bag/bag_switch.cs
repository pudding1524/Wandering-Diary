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
            bag.SetActive(true);
            Time.timeScale = 0f;
            //button = bag.transform.GetChild(0).GetComponent<Button>();
            //button.Select();
        }
    }

    public void timecale_normal()
    {
        Time.timeScale = 1f;
    }
}
