using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[Serializable]
public class Person : BarObject
{

    [NonSerialized] public int index;
    [NonSerialized] public Vector3 position;
    
    public Sprite topDownSprite;
    public Sprite forwardSprite;

    public Person(Sprite tdSprite, Sprite fSprite)
    {
        topDownSprite = tdSprite;
        forwardSprite = fSprite;
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
