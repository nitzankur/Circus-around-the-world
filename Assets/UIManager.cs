using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Serializable]
    struct AnimalIcon
    {
        public RawImage image;
        public Texture tex;
    }
    
    [SerializeField] private AnimalIcon penguinIcon, bearIcon, tigerIcon, elephantIcon;
    [SerializeField] private TextMeshProUGUI worldName, worldProgress;
    
    private static UIManager _shared;

    void Start()
    {
        if (_shared == null)
        {
            _shared = this;
        }
    }
    
    public static void ChangeTexture(String world)
    {
        _shared.SetTexture(world);
    }

    private void SetTexture(string world)
    {
        if (world.Equals(GameManager.Antarctica)) penguinIcon.image.texture = penguinIcon.tex;
        if (world.Equals(GameManager.Desert)) bearIcon.image.texture = bearIcon.tex;
        if (world.Equals(GameManager.Savanna)) tigerIcon.image.texture = tigerIcon.tex;
        if (world.Equals(GameManager.Jungle)) elephantIcon.image.texture = elephantIcon.tex;
    }

    public static void UpdateProgress()
    {
        World world = GameManager.CurrWorld();
        if(world == null)
            return;
        _shared.worldName.text = $"{world.Name}:";
        _shared.worldProgress.text = $"{Math.Round(world.Progress, 2)}%";
    }
}
