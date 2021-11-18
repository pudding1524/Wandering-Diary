using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagUIManager : MonoBehaviour
{
    ScriptableObject scriptable;
    BagData bagData;
    [SerializeField] GameObject slot;
    [SerializeField] Transform slotContent;
    
    // Start is called before the first frame update
    void Start()
    {
        //找出Resources中ScriptableObject物件
        scriptable = Resources.Load("BagData") as ScriptableObject;
        //將scriptable轉型BagData
        bagData = (BagData)scriptable;
        if (bagData.dataList.Count < 1)
        {
            return;
        }
        else
        {//遍例所有在bagData.dataList資料
            foreach (var item in bagData.dataList)
            {//叫GameManager執行CreatItem
                GameManager.Instance.CreatItem(item);
            }
        }

    }
}
