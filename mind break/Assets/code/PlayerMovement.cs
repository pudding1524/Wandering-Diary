using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigibody;
    public Animator animator;
    Vector2 movement;
    

    // Update is called once per frame
void Update()
{
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    if (movement != Vector2.zero)
        {
         animator.SetFloat("Horizontal", movement.x);
         animator.SetFloat("Vertical", movement.y);
        }

    animator.SetFloat("Speed", movement.sqrMagnitude);
}

    void FixedUpdate()
    {
        rigibody.MovePosition(rigibody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
