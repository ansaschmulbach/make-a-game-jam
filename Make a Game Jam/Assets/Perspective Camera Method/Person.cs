using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[Serializable]
public class Person
{

    [NonSerialized] public int index;
    
    public Vector3 position;
    public Sprite topDownSprite;
    public Sprite forwardSprite;
    
}
