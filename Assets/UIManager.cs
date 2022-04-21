using System;
using System.Collections;
using System.Collections.Generic;
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
    // [SerializeField] private RawImage pengRawImage,bearRawImage,tigerRawImage,elephentRawImage;
    // [SerializeField] private Texture pengTexture,BearTexture,TigerTexture,ElephentTexture;
    [SerializeField] private AnimalIcon penguinIcon, bearIcon, tigerIcon, elephantIcon;
    
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
        // if (world.Equals(GameManager.Antarctica)) pengRawImage.texture = pengTexture;
        // if (world.Equals(GameManager.Desert)) bearRawImage.texture = BearTexture;
        // if (world.Equals(GameManager.Savanna)) tigerRawImage.texture = TigerTexture;
        // if (world.Equals(GameManager.Jungle)) elephentRawImage.texture = ElephentTexture;
        if (world.Equals(GameManager.Antarctica)) penguinIcon.image.texture = penguinIcon.tex;
        if (world.Equals(GameManager.Desert)) bearIcon.image.texture = bearIcon.tex;
        if (world.Equals(GameManager.Savanna)) tigerIcon.image.texture = tigerIcon.tex;
        if (world.Equals(GameManager.Jungle)) elephantIcon.image.texture = elephantIcon.tex;
    }
}
