using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    // Start is called before the first frame update
    public WheelCollider collider;
    public GameObject cyl;

    private void FixedUpdate()
    {
        collider.motorTorque = 10;
        Quaternion quaternion = cyl.transform.rotation;
        Vector3 position = cyl.transform.position;
        
        collider.GetWorldPose(out position, out quaternion);
        
        cyl.transform.position = position;
        cyl.transform.rotation = quaternion;
    }
}
