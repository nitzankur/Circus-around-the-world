using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DefaultNamespace;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int shotLimit,areaLimit;
    
    private string state;
    private World savanna, antarctica, jungle, desert;
    public const string Savanna = "Savanna";
    public const string Antarctica = "Antarctica";
    public const string Desert = "Desert";
    public const string Jungle = "Jungle";
    private static GameManager _shared;

    private void Start()
    {
        savanna = new World(Savanna, _shared.shotLimit, _shared.areaLimit);
        antarctica = new World(Antarctica, _shared.shotLimit, _shared.areaLimit);
        desert = new World(Desert, _shared.shotLimit, _shared.areaLimit);
        jungle = new World(Jungle, _shared.shotLimit, _shared.areaLimit);
    }

    public static bool AntarcticaPaint => _shared.antarctica.Painted;

    public static bool SavannaPaint => _shared.savanna.Painted;

    public static bool DesertPaint => _shared.desert.Painted;

    public static bool JunglePaint => _shared.jungle.Painted;

    private void Awake()
    {
        if (_shared == null)
        {
            _shared = this;
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

    public static String State
    {
        get => _shared.state;
        set {_shared.state = value; UIManager.UpdateProgress();}
    }

    public static int SavannaAreaCounter
    {
        get => _shared.savanna.AreaCounter;
        set {_shared.savanna.AreaCounter = value; UIManager.UpdateProgress();}
    }

    public static int DesertAreaCounter
    {
        get => _shared.desert.AreaCounter;
        set { _shared.desert.AreaCounter = value; UIManager.UpdateProgress();}
    }

    public static int JungleAreaCounter
    {
        get => _shared.jungle.AreaCounter;
        set { _shared.jungle.AreaCounter = value; UIManager.UpdateProgress();}
    }

    public static int AntarcticaAreaCounter
    {
        get => _shared.antarctica.AreaCounter;
        set { _shared.antarctica.AreaCounter = value; UIManager.UpdateProgress();}
    }

    public static int SavannaShotCounter
    {
        get => _shared.savanna.ShotCounter;
        set { _shared.savanna.ShotCounter = value; UIManager.UpdateProgress();}
    }

    public static int DesertShotCounter
    {
        get => _shared.desert.ShotCounter;
        set { _shared.desert.ShotCounter = value; UIManager.UpdateProgress();}
    }

    public static int JungleShotCounter
    {
        get => _shared.jungle.ShotCounter;
        set { _shared.jungle.ShotCounter = value; UIManager.UpdateProgress();}
    }

    public static int AntarcticaShotCounter
    {
        get => _shared.antarctica.ShotCounter;
        set { _shared.antarctica.ShotCounter = value; UIManager.UpdateProgress();}
    }

    public static World CurrWorld()
    {
        switch (State)
        {
            case Antarctica:
                return _shared.antarctica;
            case Desert:
                return _shared.desert;
            case Jungle:
                return _shared.jungle;
            case Savanna:
                return _shared.savanna;
        }

        return null;
    }
    
    // private void PaintWorld()
    // {
    //     if (GameManager.antarcticaShotCounter >= shotLimit && GameManager.antarcticaAreaCounter >= areaLimit) GameManager.antarcticaPaint = true;
    //     if (GameManager.jungleShotCounter >= shotLimit && GameManager.jungleAreaCounter >=areaLimit) GameManager.JunglePaint = true;
    //     if (GameManager.savannaShotCounter >= shotLimit && GameManager.savannaAreaCounter >=areaLimit) GameManager.savannaPaint = true;
    //     if (GameManager.desertShotCounter >= shotLimit && GameManager.desertAreaCounter >=areaLimit) GameManager.DesertPaint = true;
    // }
}
