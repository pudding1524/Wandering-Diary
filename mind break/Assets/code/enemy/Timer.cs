using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float maxTime;     //設定最大值
    [SerializeField] private float currentTime; //當前時間
    [SerializeField] private Text timeDisplay;  //文字檔
    [SerializeField] private bool Clearance; //確認是否通關
    [SerializeField] private Animator ClearanceAinmation;
    public string SceneLoad;
    public GameObject button;


    private void Awake()
    {
        currentTime = maxTime;
        timeDisplay.text = maxTime.ToString();
    }
    
    void Update()
    {
        if(!Clearance)
        {currentTime -= Time.deltaTime;
        timeDisplay.text = ((int)currentTime).ToString();
        }

        AlertColor();
        checkClear();
    }

    private void AlertColor()
    {
        if(currentTime <= 5)
        {
            timeDisplay.color = new Vector4(200, 0, 0, 255);
        }
    }

    private void checkClear()
    {
        if(currentTime <= 0)
        {
            Clearance = true;
            //ClearanceAinmation.SetBool("active", true); //animation setbool後記得要設定true或false
            ClearanceAinmation.SetTrigger("active");
            Time.timeScale = 0;
            button.SetActive(true);
        }
    }
}
