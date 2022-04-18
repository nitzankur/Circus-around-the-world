using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathMovement : MonoBehaviour
{
    // Use this for initialization
   
    [SerializeField]
    private Vector3 targetPos1;
    [SerializeField]
    private Vector3 targetPos2;
    [SerializeField]
    private float speed = 1f;

    [SerializeField] private float angle;
    private bool firstMove=true;
    void Update()
    {
        if(transform.position == targetPos1)
        {
            firstMove = false;
        }
        if (transform.position == targetPos2)
        {
            firstMove = true;
        }
       
        if (firstMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos1, speed* Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos2, speed* Time.deltaTime);
        }
    }
}
