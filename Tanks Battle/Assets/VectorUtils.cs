using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtils
{
    public static float GetAngle(this Vector2 v) {
        return Mathf.Atan2(v.y, v.x) * 180 / Mathf.PI;
    }
}
