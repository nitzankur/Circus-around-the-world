using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeAnimal : MonoBehaviour
{
    public RawImage m_RawImage;
    //Select a Texture in the Inspector to change to
    public Texture m_Texture;
    private bool penguin_take;
    /*void Start()
    {
        //Fetch the RawImage component from the GameObject
        m_RawImage = GetComponent<RawImage>();
    }*/

    private void Update()
    {
        if (penguin_take) m_RawImage.texture = m_Texture;
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
                    penguin_take = true;
                    childTrans.gameObject.SetActive(false);
                }
            }
        }
    }
}

