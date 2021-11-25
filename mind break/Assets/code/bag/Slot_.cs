using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_ : MonoBehaviour
{
    public Item_ slotItem;
    public Image slotImage;
    public Text slotNum;

    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotItem.detail);
    }
}
