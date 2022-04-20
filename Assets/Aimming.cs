using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Aimming : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCamera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire2"))
            ZoomIn();
        if (Input.GetButtonUp("Fire2"))
            ZoomOut();
    }
    
    private void ZoomIn()
    {
         
    }

    private void ZoomOut()
    {
    }
}
