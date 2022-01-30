using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour
{
    [Header("Move Setting")]
    public float moveRangeX = 3.5f;
    public float moveRangeYmax = 0.2f;
    public float moveRangeYmin = -1f;
    public float moveSpeed = 1.5f;
    private float posNowX = 0f;
    private float posNowY = 0f;
    private bool goRight = true;
    public float trackSpeed = 1.5f;
    public float closeRange = 1.25f;
    public Vector2 centerPos;
    private BoxCollider2D BodyCollider;

    [Header("Track Settings")]
    GameObject target;
    public float FollowRadius = 4.5f;
    private LayerMask playerFilter;
    public bool isTracking = false;


    public bool isAttacking;
    public bool isFreeze;

    void Update()
    {
        FindPlayer();
        if (!isTracking || isFreeze == true)
        {
            MoveAround();
        }
        else
        {
            if (isTracking)
            {
                Tracking();
            }
            else
            {
                MoveAround();
            }
        }
    }

    private void MoveAround()
    {
        if (!isAttacking)
        {
            if (posNowX >= moveRangeX || posNowX <= -moveRangeX)
            {
                posNowX = Mathf.Clamp(posNowX, -moveRangeX, moveRangeX);
                goRight = !goRight;
                if (goRight)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }

                if (goRight) posNowX += moveSpeed * Time.deltaTime;
                else if (!goRight) posNowX -= moveSpeed * Time.deltaTime;

                transform.position = new Vector3(centerPos.x + posNowX, centerPos.y + posNowY, 0f);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
    }

    private void FindPlayer()
    {
        bool traceMode = isTracking;
        isTracking = Physics2D.OverlapCircle(this.transform.position, FollowRadius, playerFilter);

        if (traceMode == false && isTracking == true)
        {
            Collider2D playerCol = Physics2D.OverlapCircle(this.transform.position, FollowRadius, playerFilter);
            target = playerCol.gameObject;
        }
    }

    private void Tracking()
    {
        if (target != null && !isAttacking && isFreeze == false)
        {
            Vector3 diff = new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, 0);
            if (Mathf.Abs(diff.x) <= closeRange) return;

            posNowX = Mathf.Lerp(posNowX, target.transform.position.x - centerPos.x, trackSpeed * Time.deltaTime);
            posNowX = Mathf.Clamp(posNowX, -moveRangeX, moveRangeX);
            posNowY = Mathf.Lerp(posNowY, target.transform.position.y - centerPos.y, trackSpeed * Time.deltaTime);
            posNowY = Mathf.Clamp(posNowY, moveRangeYmin, moveRangeYmax);
            transform.position = new Vector3(centerPos.x + posNowX, centerPos.y + posNowY, 0f);

            float face = Mathf.Sign(diff.x);
            goRight = (face >= 0) ? true : false;
            Vector3 faceVec = new Vector3(face, 1, 1);
            transform.localScale = faceVec;

            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            if (face >= 0)
            {
                transform.eulerAngles = Vector3.forward * angle;
            }
            else
            {
                if (angle > 90 && angle < 180)
                {
                    transform.eulerAngles = Vector3.forward * (angle -180);
                }
                else if (angle < -90 && angle > -180)
                {
                    transform.eulerAngles = Vector3.forward * (angle + 180);
                }
            }
        }
    }


}
