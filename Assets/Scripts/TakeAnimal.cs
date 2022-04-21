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
    private const string Savanna = "Savanna";
    private const string Antarctica = "Antarctica";
    private const string Desert = "Desert";
    private const string Jungle = "Jungle";


    private void Update()
    {
        ChangeTexture();
        PaintWorld();
     // print(GameManager.state);
     // print(GameManager.antarcticaAreaCounter + " areaCounter " + GameManager.antarcticaShotCounter+" shootCounter");
    }
 
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
        //print(other.name+" name");
        if (other.CompareTag(Savanna)) GameManager.state = Savanna;
        if (other.CompareTag(Antarctica)) GameManager.state = Antarctica;
        if (other.CompareTag(Desert)) GameManager.state = Desert;
        if (other.CompareTag(Jungle)) GameManager.state = Jungle;
        AreasCounter(other);
    }

    private void AreasCounter(Collider other)
    {
        if (other.CompareTag("Counter"))
        {
            print("counter");
            if (GameManager.state == Savanna)  GameManager.savannaAreaCounter++;
            else if(GameManager.state == Antarctica) GameManager.antarcticaAreaCounter++;
            else if (GameManager.state == Jungle) GameManager.jungleAreaCounter++;
            else if (GameManager.state == Jungle)  GameManager.antarcticaAreaCounter++;
            Destroy(other); 
        }
    }
    
    private void PaintWorld()
    {
        if (GameManager.antarcticaShotCounter >= shotLimit && GameManager.antarcticaAreaCounter >= areaLimit)
        {
            print("paintWorld");
            GameManager.antarcticaPaint = true;
        }
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

