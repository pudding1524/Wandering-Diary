using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/New Item")]
public class Item_ : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int count;
    [TextArea]
    public string detail;

    public bool equips;

}
