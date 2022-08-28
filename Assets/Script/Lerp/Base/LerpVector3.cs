using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpVector3 : LerpBase
{
    public Vector3 start;
    public Vector3 end;

    public virtual Vector3 target { get; set; }

    protected override void _Lerp(float t)
    {
        target = Vector3.LerpUnclamped(start, end, t);
    }
}
