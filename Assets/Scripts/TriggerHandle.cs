using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHandle : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (TutorialManager.State < TutorialManager.INTERACT)
            return;
        
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

                if (disappear)
                {
                    childTrans.gameObject.SetActive(false);
                    GameManager.TakenAnimals++;
                }
            }
        }

        if (other.CompareTag("Gate"))
        {
            print("gate");
            if(Input.GetKeyDown(KeyCode.Space))
                TutorialManager.StartGame();
        }
        
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            GameManager.ClosestRespawn = other.gameObject;
        }
        
        if (other.CompareTag(GameManager.Savanna)
            || other.CompareTag(GameManager.Antarctica)
            || other.CompareTag(GameManager.Desert) 
            || other.CompareTag(GameManager.Jungle))
        {
            GameManager.State = other.tag;
            AreasCounter(other);
        }

        if (other.CompareTag("Water"))
        {
            GameManager.ResetCharacter();
        }
    }

    private void AreasCounter(Collider other)
    {
        if (other.CompareTag("Counter"))
        {
            if (GameManager.State == GameManager.Savanna)  GameManager.SavannaAreaCounter++;
            else if(GameManager.State == GameManager.Antarctica) GameManager.AntarcticaAreaCounter++;
            else if (GameManager.State == GameManager.Jungle) GameManager.JungleAreaCounter++;
            else if (GameManager.State == GameManager.Desert)  GameManager.DesertAreaCounter++;
            Destroy(other); 
        }
    }


}

