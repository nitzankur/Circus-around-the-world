using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int shotLimit,areaLimit;
    private string state;
    private int antarcticaShotCounter,desertShotCounter,savannaShotCounter,jungleShotCounter;
    private int antarcticaAreaCounter,desertAreaCounter,savannaAreaCounter,jungleAreaCounter;
    public const string Savanna = "Savanna";
    public const string Antarctica = "Antarctica";
    public const string Desert = "Desert";
    public const string Jungle = "Jungle";
    private bool antarcticaPaint, savannaPaint,desertPaint,junglePaint;

    public static bool AntarcticaPaint
    {
        get => _shared.antarcticaPaint;
        set => _shared.antarcticaPaint = value;
    }

    public static bool SavannaPaint
    {
        get => _shared.savannaPaint;
        set => _shared.savannaPaint = value;
    }

    public static bool DesertPaint
    {
        get => _shared.desertPaint;
        set => _shared.desertPaint = value;
    }

    public static bool JunglePaint
    {
        get => _shared.junglePaint;
        set => _shared.junglePaint = value;
    }

    private static GameManager _shared;

    private void Awake()
    {
        if (_shared == null)
        {
            _shared = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(State)
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
        if (other.CompareTag(Savanna)) State = Savanna;
        if (other.CompareTag(Antarctica)) State = Antarctica;
        if (other.CompareTag(Desert)) State = Desert;
        if (other.CompareTag(Jungle)) State = Jungle;
    }

    public static bool IsWorld(String tag)
    {
        return tag.Equals(Antarctica) || tag.Equals(Savanna) || tag.Equals(Desert) || tag.Equals(Jungle);
    }

    public static void SetState(String tag)
    {
        State = Savanna;
    }

    public static String State
    {
        get => _shared.state;
        set => _shared.state = value;
    }

    public static int SavannaAreaCounter
    {
        get => _shared.savannaAreaCounter;
        set
        {
            _shared.savannaAreaCounter = value;
            _shared.savannaPaint = _shared.savannaAreaCounter >= _shared.areaLimit &&
                                   _shared.savannaShotCounter >= _shared.shotLimit;

        }
    }
    public static int DesertAreaCounter
    {
        get => _shared.desertAreaCounter;
        set
        {
            _shared.desertAreaCounter = value;
            _shared.desertPaint = _shared.desertAreaCounter >= _shared.areaLimit &&
                                   _shared.desertShotCounter >= _shared.shotLimit;

        }
    }
    public static int JungleAreaCounter
    {
        get => _shared.jungleAreaCounter;
        set
        {
            _shared.jungleAreaCounter = value;
            _shared.junglePaint = _shared.jungleAreaCounter >= _shared.areaLimit &&
                                   _shared.jungleShotCounter >= _shared.shotLimit;

        }
    }
    public static int AntarcticaAreaCounter
    {
        get => _shared.antarcticaAreaCounter;
        set
        {
            _shared.antarcticaAreaCounter++;
            _shared.antarcticaPaint = _shared.antarcticaAreaCounter >= _shared.areaLimit &&
                                   _shared.antarcticaShotCounter >= _shared.shotLimit;

        }
    }
    
    public static int SavannaShotCounter
    {
        get => _shared.savannaShotCounter;
        set
        {
            _shared.savannaShotCounter = value;
            _shared.savannaPaint = _shared.savannaAreaCounter >= _shared.areaLimit &&
                                   _shared.savannaShotCounter >= _shared.shotLimit;

        }
    }
    public static int DesertShotCounter
    {
        get => _shared.desertShotCounter;
        set
        {
            _shared.desertShotCounter = value;
            _shared.desertPaint = _shared.desertAreaCounter >= _shared.areaLimit &&
                                  _shared.desertShotCounter >= _shared.shotLimit;

        }
    }
    public static int JungleShotCounter
    {
        get => _shared.jungleShotCounter;
        set
        {
            _shared.jungleShotCounter = value;
            _shared.junglePaint = _shared.jungleAreaCounter >= _shared.areaLimit &&
                                  _shared.jungleShotCounter >= _shared.shotLimit;

        }
    }
    public static int AntarcticaShotCounter
    {
        get => _shared.antarcticaShotCounter;
        set
        {
            _shared.antarcticaShotCounter++;
            _shared.antarcticaPaint = _shared.antarcticaAreaCounter >= _shared.areaLimit &&
                                      _shared.antarcticaShotCounter >= _shared.shotLimit;

        }
    }
    
    // private void PaintWorld()
    // {
    //     if (GameManager.antarcticaShotCounter >= shotLimit && GameManager.antarcticaAreaCounter >= areaLimit) GameManager.antarcticaPaint = true;
    //     if (GameManager.jungleShotCounter >= shotLimit && GameManager.jungleAreaCounter >=areaLimit) GameManager.JunglePaint = true;
    //     if (GameManager.savannaShotCounter >= shotLimit && GameManager.savannaAreaCounter >=areaLimit) GameManager.savannaPaint = true;
    //     if (GameManager.desertShotCounter >= shotLimit && GameManager.desertAreaCounter >=areaLimit) GameManager.DesertPaint = true;
    // }
}
