using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bag_switch : MonoBehaviour
{
    public GameObject bag;
    //public GameObject Bag_Canvas;
    public GameObject _select;
    [SerializeField] private Button button;
List<Button>() =
    private void Start()
    {
        _select.GetComponent<Button>().Select();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bag.SetActive(true);
            Time.timeScale = 0f;
            Canvas_Open();
        }
    }

    private void Canvas_Open()
    {
        button = bag.transform.GetChild(0).GetComponent<Button>();
        button.Select();
    }
}
