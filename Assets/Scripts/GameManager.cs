using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string state;
    public static int antarcticaShotCounter,desertShotCounter,savannaShotCounter,jungleShotCounter;
    public static int antarcticaAreaCounter,desertAreaCounter,savannaAreaCounter,jungleAreaCounter;
    public const string Savanna = "Savanna";
    public const string Antarctica = "Antarctica";
    public const string Desert = "Desert";
    public const string Jungle = "Jungle";
    public static bool antarcticaPaint, savannaPaint,DesertPaint,JunglePaint;
    private static GameManager _shared;

    private void Awake()
    {
        _shared = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case Savanna:
                break;
            case Antarctica:
                break;
            case Desert:
                break;
            case Jungle:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Savanna)) state = Savanna;
        if (other.CompareTag(Antarctica)) state = Antarctica;
        if (other.CompareTag(Desert)) state = Desert;
        if (other.CompareTag(Jungle)) state = Jungle;
    }
    
}
