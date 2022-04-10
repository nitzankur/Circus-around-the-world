using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UnicycleController : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelCollider;
    [SerializeField] private Transform wheel;
    [SerializeField] private float maxMotor = 10;
    [SerializeField] private float maxAngle = 5;

    private float _vert, _horz;
    private float _steeringAngle;

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPosition();
    }

    private void UpdateWheelPosition()
    {
        Vector3 _pos = wheel.position;
        Quaternion _quat = wheel.rotation;

        wheelCollider.GetWorldPose(out _pos, out _quat);
        
        wheel.position = _pos;
        wheel.rotation = _quat;
    }

    private void Accelerate()
    {
        wheelCollider.motorTorque = _vert * maxMotor;
    }

    private void Steer()
    {
        _steeringAngle = maxAngle * _horz;
        wheelCollider.steerAngle = _steeringAngle;
        
    }
    
    

    private void GetInput()
    {
        _vert = Input.GetAxis("Vertical") * maxMotor;
        _horz = Input.GetAxis("Horizontal") * maxAngle;
    }
    
    
}
