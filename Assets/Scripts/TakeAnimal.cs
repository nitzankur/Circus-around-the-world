using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAnimal : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            print("animal");
            other.enabled = false;
        }
    }
}
