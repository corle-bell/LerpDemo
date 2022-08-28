using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Lerp/LerpGraphicColor")]
public class LerpGraphicColor : LerpColor
{
    public Graphic graphic;

    public override Color target
    {
        get
        {
            return graphic.color;
        }
        set
        {
            graphic.color = value;
        }
    }

    private void Reset()
    {
        graphic = GetComponent<Graphic>();
    }
}