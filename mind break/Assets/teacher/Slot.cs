using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    public Text nameText;
    public Text countText;
    public Image image;
    public slotData slotData;
    Button button;

    private void Start()
    {
        nameText.text = slotData.name;
        countText.text = slotData.count.ToString();
        image.sprite = slotData.iconimage;
    }
    private void Update()
    {
        if (slotData.count < 1)
        {
            Destroy(this.gameObject, .5f);
        }
    }
    private void LateUpdate()
    {
        countText.text = slotData.count.ToString();
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
        GameManager.Instance.RemoveItem(nameText.text);
    }
}
[System.Serializable]
public struct slotData
{
    [Tooltip("道具名稱")]
    public string name;
    [Tooltip("道具數量")]
    public int count;
    [Tooltip("道具圖片")]
    public Sprite iconimage;
   
}