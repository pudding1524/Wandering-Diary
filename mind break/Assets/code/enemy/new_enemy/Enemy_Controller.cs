using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Controller : MonoBehaviour
{
    private Animator _myAnim;
    public Transform _target;

    [SerializeField]
    private float speed;
    

    [SerializeField] 
    private float range;
    void Start()
    {
        _myAnim = GetComponent<Animator>();
        //_target = FindObjectOfType<PlayerMovement>().transform;
    }
    
    void Update()
    {
        if (Vector3.Distance(_target.position, transform.position) <= range)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        _myAnim.SetBool("IsMoving", true);
        _myAnim.SetFloat("moveX", (_target.position.x - transform.position.x));
        _myAnim.SetFloat("moveY", (_target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);   
    }
}
