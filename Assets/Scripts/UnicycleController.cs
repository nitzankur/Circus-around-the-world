using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UnicycleController : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelCollider;
    [SerializeField] private Transform wheel;
    [SerializeField] private Transform seat;
    [SerializeField] private float maxMotor = 10;
    [SerializeField] private float maxAngle = 5;
    [SerializeField] private float brakes = 5;

    private float lastAngle = 0;

    private float _vert, _horz;
    private float _steeringAngle;
    private float direction;

    private float _mouseX;
    private float _mouseY;
    
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

        float rotationYDelta = _quat.eulerAngles.y - wheel.eulerAngles.y;
        
        wheel.position = _pos;
        wheel.rotation = _quat;

        //
        // if (Math.Abs(rotationYDelta) > maxAngle)
        //     rotationYDelta %= maxAngle;
        //
       // print(wheel.eulerAngles.y);
        Vector3 seatRotation = seat.eulerAngles;
        seatRotation.y = wheel.eulerAngles.y;
        if (Math.Abs(seatRotation.y - lastAngle) >= 170)
        {
            print($"{lastAngle},{ seatRotation.y}");
            seatRotation.y %= 180;
            print(seatRotation);
        }
        
        seat.eulerAngles = seatRotation;

        lastAngle = seatRotation.y;
    }

    private void Accelerate()
    {
        if (wheelCollider.brakeTorque != 0)
        {
            return;
        }
        wheelCollider.motorTorque = _vert * maxMotor;
    }

    private void Steer()
    {
        // _steeringAngle = maxAngle * _horz;
        if(_mouseX != 0)
            _steeringAngle += _mouseX * 5;
        wheelCollider.steerAngle = _steeringAngle;
        // wheelCollider.steerAngle += direction * 5;
    }
    
    

    private void GetInput()
    {
        float currVert = Input.GetAxis("Vertical") * maxMotor;
        float currHorz = Input.GetAxis("Horizontal") * maxAngle;

        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");
        
        wheelCollider.brakeTorque = (_vert == currVert && Math.Abs(currVert) < 1) ? brakes : 0;
        
        _vert = currVert;
        _horz = currHorz;

        if (Input.GetKey(KeyCode.D))
            direction = (direction >= 1) ? 1 : direction + 1;
        
        else if (Input.GetKey(KeyCode.A))
            direction = (direction <= -1) ? -1 : direction - 1;
        else
            direction = 0;
    }
    
    
}
