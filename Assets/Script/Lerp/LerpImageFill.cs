using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Lerp/LerpImageFill")]
public class LerpImageFill : LerpFloat
{
    public Image fill;
    public override float target {
        get {
            return fill.fillAmount;
        }
        set {
            fill.fillAmount = value;
        }
    }

    private void Reset()
    {
        fill = GetComponent<Image>();
    }
}
