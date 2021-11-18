using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void FixedUpdate()
    {
        Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.Translate(vector*Time.deltaTime*5f);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {//如果我碰到的Collider2D標籤為Item
        if (target.CompareTag("Item"))
        {//獲得target身上的Item
            Item item = target.GetComponent<Item>();
            //告訴GameManager去增加道具以item的itemdata
            GameManager.Instance.AddItem(item.itemdata);
            //0.5秒後移除target
            Destroy(target.gameObject, .5f);
        }   
    }
    
}
