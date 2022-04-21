using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shot : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    private CinemachineImpulseSource impulseSource;
    private float curTime;

    [SerializeField]
    private float shotDiff = 0.3f;

    // Update is called once per frame
    void Update()
    {

        //short click
         if (Input.GetButtonDown("Fire1"))
         {
             curTime = Time.time;
             ShortSooting();
         }

         if (Input.GetButton("Fire1"))
         {
             if ((Time.time - curTime) > 0.2f)
             {
                 while (Time.time - curTime > shotDiff)
                 {
                     ShortSooting();
                     curTime = Time.time + 0.2f;
                     break;
                 }
             }
         }
    }

    private void ShotWaiter()
    {
   ;
    }

    private void ShortSooting()
    {
        Instantiate(bullet, transform.position, transform.parent.rotation);
        if (GameManager.state == GameManager.Antarctica) GameManager.antarcticaShotCounter++;
        else if (GameManager.state == GameManager.Desert) GameManager.desertShotCounter++;
        else if (GameManager.state == GameManager.Savanna) GameManager.savannaShotCounter++;
        else if (GameManager.state == GameManager.Jungle ) GameManager.jungleShotCounter++;
    }
    
    
    
}