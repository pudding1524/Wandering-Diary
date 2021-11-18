using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] ScriptableObject scriptable;
    BagData bagData;
    Itemdata _itemdata;
    int _id;
    [SerializeField] GameObject slot;
    [SerializeField] Transform slotContent;

                          // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {//找出Resources中ScriptableObject物件
        scriptable = Resources.Load("BagData") as ScriptableObject;
        //將scriptable轉型BagData
        bagData = (BagData)scriptable;

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearList();
        }

    }
   

    /// <summary>
    /// 添加道具
    /// </summary>
    public void AddItem(Itemdata itemdata)
    {
        if (!bagData.dataList.Exists(x => x.itemName.Contains(itemdata.itemName)))
        {
           
            bagData.dataList.Add(itemdata);
            CreatItem(itemdata);
        }
        else
        {
            if (!itemdata.canRepeat)
            {
                
                bagData.dataList.Add(itemdata);
                CreatItem(itemdata);
                return;
            }//在bagData.dataList清單中找到itemName的內容存到_itemdata
            _itemdata = bagData.dataList.Find(x => x.itemName.Contains(itemdata.itemName));
            //移除清單中所有的紀錄
            bagData.dataList.RemoveAll(x => x.itemName.Contains(itemdata.itemName));
           //改寫
            _itemdata.itemCount++;
            //重新添加至清單
            bagData.dataList.Add(_itemdata);
            //刷新UI
            ItemUIUpdate(_itemdata.itemName, _itemdata.itemCount);
        }
       
    }
    
    /// <summary>
    /// 移除道具
    /// </summary>
    public void RemoveItem(string itemName)
    {//檢查bagData.dataList是否存在itemName的內容
        //如果不存在則不做事
        if (!bagData.dataList.Exists(x => x.itemName.Contains(itemName)))
        {
            return;
        }
        else
        {//在bagData.dataList清單中找到itemName的內容存到_itemdata
            _itemdata = bagData.dataList.Find(x => x.itemName.Contains(itemName));
            //如果_itemdata.itemCount>0表示有這個道具
            if (_itemdata.itemCount>0)
            {//移除清單中的紀錄
                bagData.dataList.Remove(_itemdata);
                //改寫
                _itemdata.itemCount--;
                
                //重新添加至清單
                bagData.dataList.Add(_itemdata);
                //刷新UI
                ItemUIUpdate(_itemdata.itemName, _itemdata.itemCount);
            }
           
            if (_itemdata.itemCount==0)
            {
                //從清單中移除
                bagData.dataList.Remove(_itemdata);
            }
            
        }
    }
    
    public void ClearList()
    {
        bagData.dataList.Clear();//把清單清除
    }
    /// <summary>
    /// 刷新ItemUI顯示
    /// </summary>
    /// <param name="name">道具名稱</param>
    /// <param name="count">道具數量</param>
    private void ItemUIUpdate(string name,int count)
    {//找尋場景上名稱與name相同物件
        var g =GameObject.Find(name);
        //更新slotData道具數量
        g.GetComponent<Slot>().slotData.count= count;
       
    }
    /// <summary>
    /// 生成道具
    /// </summary>
    /// <param name="itemdata"></param>
  public void CreatItem(Itemdata itemdata)
    {
        var temp = Instantiate(slot, slotContent);
        temp.name = itemdata.itemName;
        temp.GetComponent<Slot>().slotData.name = temp.name;
        temp.GetComponent<Slot>().slotData.count = itemdata.itemCount;
        temp.GetComponent<Slot>().slotData.iconimage = itemdata.sprite;
        
    }
}
