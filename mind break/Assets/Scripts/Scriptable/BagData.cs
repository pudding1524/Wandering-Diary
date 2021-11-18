using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data", fileName = "BagData")]
public class BagData : ScriptableObject
{
    public List<Itemdata> dataList = new List<Itemdata>();

}
[System.Serializable]
public struct Itemdata
{
    [Tooltip("道具名稱")]
    public string itemName;
    [Tooltip("道具數量")]
    public int itemCount;
    [Tooltip("是否可疊加")]
    public bool canRepeat;
    [Tooltip("道具Icon")]
    public Sprite sprite;
   
}