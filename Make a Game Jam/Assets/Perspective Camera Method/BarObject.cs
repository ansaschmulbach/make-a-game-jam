using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public interface BarObject
{

    Vector3 GetPosition();
    Sprite TopDownSprite();
    Sprite FrontSprite();

}
