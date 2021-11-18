using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/New Item")]
public class item : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public int count;
    [TextArea]
    public string detail;

    public bool equips;

}
