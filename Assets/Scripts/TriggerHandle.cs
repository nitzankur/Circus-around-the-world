using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHandle : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Animal") && Input.GetKeyDown(KeyCode.Space))
        {
            print("Animal");
            Transform childTrans = other.transform.Find("Animal");
            print(other.transform.Find("Animal")+" find");
            var disappear = true;
            if (childTrans)
            {
                if (GameManager.State == GameManager.Antarctica && GameManager.AntarcticaPaint || 
                        GameManager.State == GameManager.Desert && GameManager.DesertPaint ||
                        GameManager.State == GameManager.Savanna && GameManager.SavannaPaint ||
                        GameManager.State == GameManager.Jungle && GameManager.JunglePaint) UIManager.ChangeTexture(GameManager.State);
                else disappear = false;
                if(disappear) childTrans.gameObject.SetActive(false);
            }
        }
    }
    //change the state of the world
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameManager.Savanna)) GameManager.State = GameManager.Savanna;
        if (other.CompareTag(GameManager.Antarctica)) GameManager.State = GameManager.Antarctica;
        if (other.CompareTag(GameManager.Desert)) GameManager.State = GameManager.Desert;
        if (other.CompareTag(GameManager.Jungle)) GameManager.State = GameManager.Jungle;
        AreasCounter(other);
    }

    private void AreasCounter(Collider other)
    {
        if (other.CompareTag("Counter"))
        {
            print("counter");
            if (GameManager.State == GameManager.Savanna)  GameManager.SavannaAreaCounter++;
            else if(GameManager.State == GameManager.Antarctica) GameManager.AntarcticaAreaCounter++;
            else if (GameManager.State == GameManager.Jungle) GameManager.JungleAreaCounter++;
            else if (GameManager.State == GameManager.Desert)  GameManager.DesertAreaCounter++;
            Destroy(other); 
        }
    }


}

