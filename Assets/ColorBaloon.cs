using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ColorBaloon : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Paintable p = other.collider.GetComponent<Paintable>();
        if(p != null){
            Vector3 pos = transform.position;
            PaintManager.instance.paint(p, pos);
        }
        
        Destroy(gameObject);
    }
}
