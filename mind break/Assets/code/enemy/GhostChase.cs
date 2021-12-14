using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GhostChase : MonoBehaviour
{
    public enum Enemy_Speed
    {
        Speed_up,
        Speed_normal
    }
    public Enemy_Speed enemy_Speed;


    public float speed;
    public float startWaitTime;
    public float waitTime;

    public Transform movePos;
    public Transform MaxPos;
    public Transform MinPos;
    public Transform target;

    public GameObject gameover;

    public static GhostChase Instance;

    private void Awake()
    {
        Instance = this;
    }

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
        switch (enemy_Speed)
        {
            case Enemy_Speed.Speed_normal:
               
                Speed_normal();
                
                if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
                {
                    if (waitTime <= 0)
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

                break;

            case Enemy_Speed.Speed_up:
                Speed_Change_Up();

                if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
                {
                    if (waitTime <= 0)
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
                break;
        }
        
        
        

    }


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        gameover.SetActive(true);
    //        Time.timeScale = 0f;
    //    }   
    //}

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


    public void Speed_Change_Up()
    {
        speed = 10;
        enemy_Speed = Enemy_Speed.Speed_up;
        
    }

    public void Speed_normal()
    {
        speed = 5;
        enemy_Speed = Enemy_Speed.Speed_normal;
    }
}
