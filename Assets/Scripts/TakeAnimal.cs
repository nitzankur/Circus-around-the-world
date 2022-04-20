using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeAnimal : MonoBehaviour
{
    [SerializeField] private RawImage pengRawImage,bearRawImage,tigerRawImage,elephentRawImage;
    [SerializeField] private Texture pengTexture,BearTexture,TigerTexture,ElephentTexture;
    [SerializeField] private int shotLimit,areaLimit; 
    private bool penguinTake,bearTake,tigerTake,elephentTake;
    private bool savanna1, savanna2, savanna3, savanna4, savanna5;
    private bool antarctica1, antarctica2, antarctica3, antarctica4, antarctica5;
    private const string Savanna = "Savanna";
    private const string Antarctica = "Antarctica";
    private const string Desert = "Desert";
    private const string Jungle = "Jungle";


    private void Update()
    {
        ChangeTexture();
        PaintWorld();
        // print(GameManager.state+" state");
    }
    //change the boolean vareibal 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Animal") && Input.GetKeyDown(KeyCode.Space))
        {
            Transform childTrans = other.transform.Find("Animal");
            print(other.transform.Find("Animal"));
            var disappear = true;
            if (childTrans)
            {
                if (GameManager.state == Antarctica && GameManager.antarcticaPaint) penguinTake = true;
                else if (GameManager.state == Desert && GameManager.DesertPaint) bearTake = true;
                else if (GameManager.state == Savanna && GameManager.savannaPaint) tigerTake = true;
                else if (GameManager.state == Jungle && GameManager.JunglePaint) elephentTake = true;
                else disappear = false;
                if(disappear) childTrans.gameObject.SetActive(false);
            }
        }
    }
    //change the state of the world
    private void OnTriggerEnter(Collider other)
    {
        print(other.name+" name");
        if (other.CompareTag(Savanna)) GameManager.state = Savanna;
        if (other.CompareTag(Antarctica)) GameManager.state = Antarctica;
        if (other.CompareTag(Desert)) GameManager.state = Desert;
        if (other.CompareTag(Jungle)) GameManager.state = Jungle;
        AreasCounterSavana(other);
       
    }

    private void AreasCounterSavana(Collider other)
    {
        if(!savanna1)
        {
            if (other.CompareTag("SavannaCounter1")) 
            {GameManager.savannaAreaCounter++;savanna1 = true;}
        }

        if (!savanna2)
        {
            if (other.CompareTag("SavannaCounter2")) 
            {GameManager.savannaAreaCounter++;savanna2 = true;}
        }

        if (!savanna3)
        {
            if (other.CompareTag("SavannaCounter3")) 
            {GameManager.savannaAreaCounter++;savanna3 = true;}
        }
        
        if (!savanna4)
        {
            if (other.CompareTag("SavannaCounter4")) 
            {GameManager.savannaAreaCounter++;savanna4 = true;}
        }
    }
    private void AreasCounterAntarctica(Collider other)
    {
        if(!antarctica1)
        {
            if (other.CompareTag("SavannaCounter1")) 
            {GameManager.antarcticaAreaCounter++;antarctica1 = true;}
        }

        if (!antarctica2)
        {
            if (other.CompareTag("SavannaCounter2")) 
            {GameManager.antarcticaAreaCounter++;antarctica2 = true;}
        }

        if (!antarctica3)
        {
            if (other.CompareTag("SavannaCounter3")) 
            {GameManager.antarcticaAreaCounter++;antarctica3 = true;}
        }
        
        if (!antarctica4)
        {
            if (other.CompareTag("SavannaCounter4")) 
            {GameManager.antarcticaAreaCounter++;antarctica4 = true;}
        }
    }
    private void PaintWorld()
    {
        if (GameManager.antarcticaShotCounter >= shotLimit && GameManager.antarcticaAreaCounter >=areaLimit) GameManager.antarcticaPaint = true;
        if (GameManager.jungleShotCounter >= shotLimit && GameManager.jungleAreaCounter >=areaLimit) GameManager.JunglePaint = true;
        if (GameManager.savannaShotCounter >= shotLimit && GameManager.savannaAreaCounter >=areaLimit) GameManager.savannaPaint = true;
        if (GameManager.desertShotCounter >= shotLimit && GameManager.desertAreaCounter >=areaLimit) GameManager.DesertPaint = true;
    }

    private void ChangeTexture()
    {
        if (penguinTake) pengRawImage.texture = pengTexture;
        if (bearTake) bearRawImage.texture = BearTexture;
        if (tigerTake) tigerRawImage.texture = TigerTexture;
        if (elephentTake) elephentRawImage.texture = ElephentTexture;
    }
}

