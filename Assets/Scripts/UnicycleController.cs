using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;

public class UnicycleController : MonoBehaviour
{
    #region Inspector

    [SerializeField] private WheelCollider wheelCollider;
    [SerializeField] private Transform wheel;
    [SerializeField] private Transform seat;
    [SerializeField] private Transform body;
    [SerializeField] private Transform followRotation;
    [SerializeField] private float speed = 10;
    [SerializeField] private float brakes = 1000;
    [SerializeField] private float turnSpeed = 0.3f;
    [SerializeField] private float ySensitivity;

    [SerializeField] private Cinemachine.AxisState xAxis;
    [SerializeField] private Cinemachine.AxisState yAxis;

    #endregion

    #region Fields

    private float vertInput, horizInput;
    private float steeringAngle;

    private new Rigidbody rigidbody;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdatePosition();
    }

    #endregion


    #region Methods

    private void UpdatePosition()
    {
        Vector3 _pos = wheel.position;
        Quaternion _quat = wheel.rotation;

        wheelCollider.GetWorldPose(out _pos, out _quat);

        // Vector3 euler = _quat.eulerAngles;
        // euler.y = wheel.eulerAngles.y;
        //
        // _quat.eulerAngles = euler;

        wheel.position = _pos;
        wheel.rotation = _quat;

        // float followY = Math.Abs(wheel.eulerAngles.y - followRotation.eulerAngles.y) > 120 ? xAxis.Value : wheel.eulerAngles.y - horizInput; 
        followRotation.transform.rotation = Quaternion.Slerp(followRotation.transform.rotation, Quaternion.Euler(0, xAxis.Value, 0), turnSpeed);
        seat.transform.eulerAngles = followRotation.transform.eulerAngles + new Vector3(0, horizInput, 0);
        
        body.transform.rotation = Quaternion.Slerp(body.transform.rotation, quaternion.Euler(yAxis.Value * ySensitivity,0,0), turnSpeed);
        Vector3 bodyRotation = body.transform.eulerAngles;
        bodyRotation.y = followRotation.eulerAngles.y;
        body.transform.eulerAngles = bodyRotation;
    }

    private void Accelerate()
    {
        if (wheelCollider.brakeTorque != 0)
        {
            rigidbody.velocity = new Vector3(0,rigidbody.velocity.y,0);
            return;
        }
        wheelCollider.motorTorque = vertInput * speed;
    }

    private void Steer()
    {
        steeringAngle = xAxis.Value + horizInput;
        wheelCollider.steerAngle = steeringAngle;
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("reset");
            wheelCollider.steerAngle = wheel.eulerAngles.y;
        }
        
        xAxis.Update(Time.fixedDeltaTime);
        yAxis.Update(Time.fixedDeltaTime);
        
        float currVert = Input.GetAxis("Vertical") * speed;
        horizInput = Input.GetAxis("Horizontal") * 90;

        if (vertInput == currVert && Math.Abs(currVert) < 1 || vertInput * currVert < 0) 
            wheelCollider.brakeTorque = brakes;
        else
            wheelCollider.brakeTorque = 0;

        vertInput = currVert;
    }

    #endregion
}
