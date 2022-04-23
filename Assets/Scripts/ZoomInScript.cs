using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ZoomInScript : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera;
    
    private Animator animator;
    private static readonly int Zoom = Animator.StringToHash("Zoom");

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator = vCamera.GetComponent<Animator>();
    }

    private void Update()
    {
        if(TutorialManager.State < TutorialManager.AIM)
            return;
        
        if (Input.GetButtonDown("Fire2"))
            ZoomIn();
        if (Input.GetButtonUp("Fire2"))
            ZoomOut();
    }
    
    private void ZoomIn()
    {
        if (TutorialManager.State == TutorialManager.AIM)
            TutorialManager.State++;
        animator.SetBool(Zoom, true);    
    }

    private void ZoomOut()
    {
        animator.SetBool(Zoom, false);
    }
}
