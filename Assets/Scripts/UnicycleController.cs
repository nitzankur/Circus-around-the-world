using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UnicycleController : MonoBehaviour
{
    #region Inspector

    [SerializeField] private WheelCollider wheelCollider;
    [SerializeField] private Transform wheel;
    [SerializeField] private Transform seat;
    [SerializeField] private Transform gun;
    [SerializeField] private float maxMotor = 10;
    [SerializeField] private float maxAngle = 5;
    [SerializeField] private float brakes = 5;
    [SerializeField] private float _speed = 7;
    
    #endregion

    #region Fields

    private float lastAngle = 0;

    private float _vert, _horz;
    private float _steeringAngle;
    private float direction;

    private bool started = false;
    
    private float _mouseX;
    private float _mouseY;

    private float rotateX, rotateY;

    #endregion

    #region MonoBehaviour

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPosition();
    }

    #endregion


    #region Methods

    private void UpdateWheelPosition()
    {
        Vector3 _pos = wheel.position;
        Quaternion _quat = wheel.rotation;

        wheelCollider.GetWorldPose(out _pos, out _quat);

        wheel.position = _pos;
        wheel.rotation = _quat;
        
        if (rotateX != 0)
        {
            Vector3 seatRotation = seat.transform.localEulerAngles;
            seatRotation.y += rotateX;
            seat.transform.localEulerAngles = seatRotation;
        }

        if (rotateY != 0)
        {
            Vector3 gunRotation = gun.transform.localEulerAngles;
            gunRotation.x -= rotateY;
            gun.transform.localEulerAngles = gunRotation;
        }
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
            _steeringAngle += rotateX;
        wheelCollider.steerAngle = _steeringAngle;
    }
    
    

    private void GetInput()
    {
        float currVert = Input.GetAxis("Vertical") * maxMotor;
        float currHorz = Input.GetAxis("Horizontal") * maxAngle;

        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        if (_vert == currVert && Math.Abs(currVert) < 1 || _vert * currVert < 0)
            wheelCollider.brakeTorque = brakes;
        else
            wheelCollider.brakeTorque = 0;

        _vert = currVert;
        _horz = currHorz;
        rotateX = _mouseX * _speed * Time.deltaTime;
        rotateY = _mouseY * _speed * Time.deltaTime;
    }

    #endregion
}
