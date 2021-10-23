using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class libraryTriger : MonoBehaviour
{
    public GameObject button;
    public string SceneLoad;
    public GameObject talkUI;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            button.SetActive(true);
        }   
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            button.SetActive(false); 
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (button.activeSelf && Input.GetKeyDown(KeyCode.Z))
        {
            
            SceneManager.LoadScene(SceneLoad);
        }
    }
}
