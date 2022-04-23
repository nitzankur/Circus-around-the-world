using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ColorBalloon : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Paintable p = other.collider.GetComponent<Paintable>();
        if(p != null){
            Vector3 pos = transform.position;
            PaintManager.instance.paint(p, pos, radius: 2);
        }
        
        Destroy(gameObject);
    }
}
