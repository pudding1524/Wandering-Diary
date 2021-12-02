using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GhostChase : MonoBehaviour
{

    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform MaxPos;
    public Transform MinPos;

    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if(waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        way_();
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameover.SetActive(true);
            Time.timeScale = 0f;
        }   
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(MaxPos.position.x, MinPos.position.x), Random.Range(MaxPos.position.y, MinPos.position.y));
        return rndPos;
    }

    public void way_()
    {
        Vector3 ghostScale = transform.localScale;
        
        if (transform.position.x < movePos.position.x)
        {
            transform.localScale = new Vector3(2 ,2,1);
        }
        else
        {
            transform.localScale = new Vector3(-2 ,2,1);
        }
    }
}
