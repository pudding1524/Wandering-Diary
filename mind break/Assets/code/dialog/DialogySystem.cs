using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogySystem : MonoBehaviour
{
    [Header("UI組件")]
    public Text textLabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textFile;
    public float textSpeed;
    public int index;

    [Header("頭像")]
    public Sprite face01, face02;

    //[Header("玩家")]
    //public GameObject Player;

    bool textFinsished;//是否完成打字
    bool cancelTyping;//取消打字
    bool talking; //是否對話中




    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }
    private void OnEnable() 
    {
        textFinsished = true;
        StartCoroutine(SetTextUI());
        Time.timeScale=1;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Z) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(textFinsished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if(!textFinsished)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinsished = false;
        textLabel.text = "";

        switch(textList[index])
        {
            case "A":
                faceImage.sprite = face01;
                index++;
                break;
            case "B":
                faceImage.sprite = face02;
                index++;
                break;
        }

        int letter = 0;
        while(!cancelTyping && letter < textList[index].Length - 1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        textFinsished = true;
        index++;
    }
        
}
