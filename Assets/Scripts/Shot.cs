using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shot : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed = 100f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private Transform parentController;
    [SerializeField] private  CinemachineFreeLook  flCam;
    public static int shoot_num = 0;
    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        // impulseSource =  flCam.GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = parentController.localEulerAngles;
        bool pressing = Input.GetMouseButton(0);
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
            shoot_num++;
        }
        
        parentController.localEulerAngles = new Vector3(Mathf.LerpAngle(parentController.localEulerAngles.x, pressing ? RemapCamera(flCam.m_YAxis.Value, 0, 1, -25, 25) : 0, .3f), angle.y, angle.z);
    }
    
    public void Shooting()
    {
        GameObject instBullet = Instantiate(bullet,transform.position ,Quaternion.identity) as GameObject;
        Rigidbody instBulletRb = instBullet.GetComponent<Rigidbody>();
        instBulletRb.AddForce(Vector3.forward*speed);
    }
    
    float RemapCamera(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
