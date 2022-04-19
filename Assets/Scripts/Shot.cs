using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shot : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform parentController;
    private Vector3 _mouseWorldPosition = Vector3.zero;
    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        // impulseSource =  flCam.GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            _mouseWorldPosition = raycastHit.point;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shooting(_mouseWorldPosition);
        }

    }

    public void Shooting(Vector3 mouseWorldPosition)
    {
        Vector3 aimDir = (mouseWorldPosition - parentController.position).normalized;
        Instantiate(bullet, transform.position, Quaternion.LookRotation(aimDir,Vector3.up));

    }
    
}