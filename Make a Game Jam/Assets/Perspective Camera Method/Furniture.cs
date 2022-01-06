using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Furniture : BarObject
{

    public Sprite topDownSprite;
    public Sprite forwardSprite;
    [NonSerialized]
    public Vector3 position;

    public Furniture(Sprite tdSprite, Sprite fSprite)
    {
        this.topDownSprite = tdSprite;
        this.forwardSprite = fSprite;
    }
    
    public Vector3 GetPosition()
    {
        return position;
    }

    public Sprite TopDownSprite()
    {
        return topDownSprite;
    }

    public Sprite FrontSprite()
    {
        return forwardSprite;
    }
}
