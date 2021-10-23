using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public float speed;

    private Animation anim;

    public float minX, maxX, minY, maxY;
    public Transform moveSpot;

    private float waitTime;
    public float startWaitTime;

    public string SceneLoad;



    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneLoad);
        }   
    }
}
