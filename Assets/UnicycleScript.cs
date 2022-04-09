using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicycleScript : MonoBehaviour
{
    private WheelCollider wheelCollider;
    private bool move;

    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move = true;
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            move = false;
        }
    }

    private void FixedUpdate()
    {
        if (move)
            wheelCollider.motorTorque = 5;
        else
            wheelCollider.motorTorque = 0;    
    }
}
