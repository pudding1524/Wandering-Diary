using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gettest : MonoBehaviour
{
    public Item_ thisGameObject;
    public Inventory Bag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        if (!Bag.itemList.Contains(thisGameObject))
        {
            Bag.itemList.Add(thisGameObject);
        }
        else
        {
            thisGameObject.count += 1;
        }

        InventoryManager.RefreshItem();
    }
}
