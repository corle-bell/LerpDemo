using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBase : MonoBehaviour
{
    protected float _percent;
    public float percent
    {
        set
        {
            _percent = value;
            Lerp(_percent);
        }
        get
        {
            return _percent;
        }
    }

    public bool isCurve=false;
    public bool isClamp=true;

    public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);

    public void Lerp(float t)
    {
        float _t = isClamp ? Mathf.Clamp01(t) : t;
        _Lerp(isCurve?curve.Evaluate(_t) : _t);
    }

    protected virtual void _Lerp(float t)
    {

    }

}
