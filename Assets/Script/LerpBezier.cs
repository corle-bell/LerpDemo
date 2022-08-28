using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBezier : MonoBehaviour
{
    public Transform begin;
    public Transform control;
    public Transform end;

    private Vector3 p_begin_control;
    private Vector3 p_control_end;
    private Vector3 p_target;

    [Range(0, 1)]
    public float percent;

    private void Logic()
    {
        for(int i=1; i<100; i++)
        {
            Vector3 a = BezierPoint((float)(i - 1) / 100);
            Vector3 b = BezierPoint((float)(i) / 100);

            DrawLine(a, b, Color.red);
        }

        DrawLine(begin.localPosition, control.localPosition, Color.black);
        DrawLine(control.localPosition, end.localPosition, Color.black);


        p_begin_control = Vector3.Lerp(begin.localPosition, control.localPosition, percent);
        p_control_end = Vector3.Lerp(control.localPosition, end.localPosition, percent);
        p_target = Vector3.Lerp(p_begin_control, p_control_end, percent);

        DrawLine(p_begin_control, p_control_end, Color.green);

    }

    private void DrawLine(Vector3 Pos0, Vector3 Pos1, Color _color)
    {
        Debug.DrawLine(transform.TransformPoint(Pos0), transform.TransformPoint(Pos1), _color);
    }

    private Vector3 BezierPoint(float _t)
    {
        var  pos = Vector3.Lerp(begin.localPosition, control.localPosition, _t);
        var pos1 = Vector3.Lerp(control.localPosition, end.localPosition, _t);
        return Vector3.Lerp(pos, pos1, _t);
    }

    private void OnDrawGizmos()
    {
        if(begin!=null && control != null && end!=null)
        {
            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(begin.localPosition, 0.5f);
            Gizmos.DrawWireSphere(p_begin_control, 0.3f);

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(control.localPosition, 0.5f);
            Gizmos.DrawWireSphere(p_target, 0.3f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(end.localPosition, 0.5f);
            Gizmos.DrawWireSphere(p_control_end, 0.3f);

            Logic();
        }
    }
}
