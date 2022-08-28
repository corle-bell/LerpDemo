using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LerpPositionType
{
    local = 0,
    world,
    ancherPos
}

[AddComponentMenu("Lerp/LerpPosition")]
public class LerpPosition : LerpVector3
{
    public LerpPositionType type;

    public override Vector3 target
    {
        get
        {
            switch (type)
            {
                case LerpPositionType.local:
                    return transform.localPosition;
                case LerpPositionType.world:
                    return transform.position;
                case LerpPositionType.ancherPos:
                    return (transform as RectTransform).anchoredPosition;
            }

            return Vector3.zero;
        }
        set
        {
            switch (type)
            {
                case LerpPositionType.local:
                    transform.localPosition = value;
                    break;
                case LerpPositionType.world:
                    transform.position = value;
                    break;
                case LerpPositionType.ancherPos:
                    (transform as RectTransform).anchoredPosition = value;
                    break;
            }
        }
    }
}