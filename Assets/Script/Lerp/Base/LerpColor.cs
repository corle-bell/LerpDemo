using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : LerpBase
{
    public Color start = Color.white;
    public Color end = Color.white;

    public virtual Color target { get; set; }

    protected override void _Lerp(float t)
    {
        target = Color.LerpUnclamped(start, end, t);
    }
}
