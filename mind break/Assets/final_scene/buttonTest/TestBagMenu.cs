using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestBagMenu : MonoBehaviour
{
    GameObject[] menuButtonobj;//選單按鈕陣列
    [SerializeField, Tooltip("選單按鈕List")] List<Button> menuButtonList = new List<Button>();
    // Start is called before the first frame update
    [SerializeField] int currentButton = 0;//初始按紐索引
    void Start()
    {
        menuButtonobj = GameObject.FindGameObjectsWithTag("menuButtonTag");//先找到場景上所有有menuButtonTag的物件存入陣列
        foreach (var item in menuButtonobj)//遍例所有在menuButtonobj中的物件
        {
            menuButtonList.Add(item.GetComponent<Button>());//將物件加入menuButtonList的清單中
        }
        menuButtonList[currentButton].Select();//選取清單中第一個按鈕
    }

    private void Update()
    {
        currentButton = Mathf.Clamp(currentButton, 0, menuButtonList.Count - 1);//限制currentButton上下限值
        if (currentButton < menuButtonList.Count - 1)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))//如果按下鍵盤右鍵按紐索引加1
            {
                currentButton++;

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))//如果按下鍵盤左鍵按紐索引減1
            {
                currentButton--;
            }
            ChooseButton(currentButton);
        }
    }
    /// <summary>
    /// 選擇按鈕
    /// </summary>
    /// <param name="ButtonIdex">按鈕索引</param>
    void ChooseButton(int ButtonIdex)
    {
        menuButtonList[ButtonIdex].Select();//選取索引中按鈕
    }
}
