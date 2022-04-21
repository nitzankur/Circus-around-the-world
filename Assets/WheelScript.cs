using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    // Start is called before the first frame update
    public WheelCollider collider;

    private void FixedUpdate()
    {
        collider.motorTorque = 10;
        Quaternion quaternion = transform.rotation;
        Vector3 position = transform.position;
        
        collider.GetWorldPose(out position, out quaternion);

        transform.rotation = quaternion;
        transform.position = position;
    }
}
