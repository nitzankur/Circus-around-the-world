using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    struct World
    {
        public String name;
        public int shotCounter;
        public int areaCounter;
        public bool painted;
    }

    [SerializeField] private int shotLimit,areaLimit;
    
    private string state;
    private World savanna, antarctica, jungle, desert;
    public const string Savanna = "Savanna";
    public const string Antarctica = "Antarctica";
    public const string Desert = "Desert";
    public const string Jungle = "Jungle";

    public static bool AntarcticaPaint
    {
        get => _shared.antarctica.painted;
        set => _shared.antarctica.painted = value;
    }

    public static bool SavannaPaint
    {
        get => _shared.savanna.painted;
        set => _shared.savanna.painted = value;
    }

    public static bool DesertPaint
    {
        get => _shared.desert.painted;
        set => _shared.desert.painted = value;
    }

    public static bool JunglePaint
    {
        get => _shared.jungle.painted;
        set => _shared.jungle.painted = value;
    }

    private static GameManager _shared;

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
        get => _shared.savanna.areaCounter;
        set
        {
            _shared.savanna.areaCounter = value;
            _shared.savanna.painted = _shared.savanna.areaCounter >= _shared.areaLimit &&
                                   _shared.savanna.shotCounter >= _shared.shotLimit;

        }
    }
    public static int DesertAreaCounter
    {
        get => _shared.desert.areaCounter;
        set
        {
            _shared.desert.areaCounter = value;
            _shared.desert.painted = _shared.desert.areaCounter >= _shared.areaLimit &&
                                   _shared.desert.shotCounter >= _shared.shotLimit;

        }
    }
    public static int JungleAreaCounter
    {
        get => _shared.jungle.areaCounter;
        set
        {
            _shared.jungle.areaCounter = value;
            _shared.jungle.painted = _shared.jungle.areaCounter >= _shared.areaLimit &&
                                   _shared.jungle.shotCounter >= _shared.shotLimit;

        }
    }
    public static int AntarcticaAreaCounter
    {
        get => _shared.antarctica.areaCounter;
        set
        {
            _shared.antarctica.areaCounter = value;
            _shared.antarctica.painted = _shared.antarctica.areaCounter >= _shared.areaLimit &&
                                   _shared.antarctica.shotCounter >= _shared.shotLimit;

        }
    }
    
    public static int SavannaShotCounter
    {
        get => _shared.savanna.shotCounter;
        set
        {
            _shared.savanna.shotCounter = value;
            _shared.savanna.painted = _shared.savanna.areaCounter >= _shared.areaLimit &&
                                   _shared.savanna.shotCounter >= _shared.shotLimit;

        }
    }
    public static int DesertShotCounter
    {
        get => _shared.desert.shotCounter;
        set
        {
            _shared.desert.shotCounter = value;
            _shared.desert.painted = _shared.desert.areaCounter >= _shared.areaLimit &&
                                  _shared.desert.shotCounter >= _shared.shotLimit;

        }
    }
    public static int JungleShotCounter
    {
        get => _shared.jungle.shotCounter;
        set
        {
            _shared.jungle.shotCounter = value;
            _shared.jungle.painted = _shared.jungle.areaCounter >= _shared.areaLimit &&
                                  _shared.jungle.shotCounter >= _shared.shotLimit;

        }
    }
    public static int AntarcticaShotCounter
    {
        get => _shared.antarctica.shotCounter;
        set
        {
            _shared.antarctica.shotCounter = value;
            _shared.antarctica.painted = _shared.antarctica.areaCounter >= _shared.areaLimit &&
                                      _shared.antarctica.shotCounter >= _shared.shotLimit;

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
