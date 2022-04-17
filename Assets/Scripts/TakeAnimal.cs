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

    private void OnTriggerStay(Collider other)
    {
        print("trigger");
        if (other.CompareTag("Animal"))
        {
            print("animal");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Transform childTrans = other.transform.Find("Animal");
                print(other.transform.Find("Animal"));
                if (childTrans)
                {
                    childTrans.gameObject.SetActive(false);
                }
            }
        }
    }
}
