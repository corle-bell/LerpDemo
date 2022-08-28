using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFloat : LerpBase
{
    public float start;
    public float end;

    public virtual float target { get; set; }

    protected override void _Lerp(float t)
    {
        target = Mathf.LerpUnclamped(start, end, t);
    }
}
