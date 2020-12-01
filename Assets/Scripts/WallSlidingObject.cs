using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlidingObject : Interactable
{
    public Quaternion positionOnSphere;

    public List<Line> rails;

    protected bool grabbing = false;

    protected Quaternion rotationOffset = new Quaternion();

    //private void OnEnable()
    //{
    //    if (debug)
    //    {
    //        foreach (Line line in rails)
    //        {
    //            GameObject lineObj = new GameObject($"Line {line.a};{line.b}");
    //            lineObj.transform.SetParent(transform);
    //            LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();
    //            lineRenderer.startWidth = 0.1f;
    //            lineRenderer.endWidth = 0.1f;
    //            lineRenderer.SetPositions(new Vector3[] { line.a.position, line.b.position });
    //        }
    //    }
    //}

    protected (Vector3?, Line) GetLookAtPosition(Quaternion rotation)
    {
        Vector3 pointingAt = Utils.PositionOnWall(rotation) + transform.parent.position;

        Vector3? minDistPosition = null;
        float minDist = float.MaxValue;
        Line bestLine = null;


        foreach (Line line in rails)
        {
            if(line.a != null && line.b != null)
            {
                Vector3 pointOnLine = Utils.NearestPointOnSegment(pointingAt, line.a.position, line.b.position);
                float dist = Vector3.Distance(pointingAt, pointOnLine);
                if (dist < minDist)
                {
                    minDist = dist;
                    minDistPosition = pointOnLine;
                    bestLine = line;
                }
            }
            else
            {
                Debug.LogError("Found a line with a null transform");
            }
            
        }

        return (minDistPosition, bestLine);
    }

    

    public override bool Process(Transform character, Vector3 m)
    {
        if (grabbing)
        {
            character.Rotate(m.y, m.x, m.z);

            var tuple = GetLookAtPosition(character.rotation);
            Vector3? onRailPosition = tuple.Item1;
            Line rail = tuple.Item2;
            if (onRailPosition != null)
            {
                character.LookAt(onRailPosition.Value, character.up);

                positionOnSphere = character.rotation;

                Vector3 movement = onRailPosition.Value - transform.position;
                //place the object on the wall at the current rotation
                transform.position = onRailPosition.Value;

                rotationOffset.SetFromToRotation(transform.forward * 2, (transform.forward *2) - movement);
                
                transform.rotation = rotationOffset * transform.rotation;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void OnDown(Vector3 hitPoint)
    {
        grabbing = true;
    }

    public override void OnUp()
    {
        grabbing = false;
    }

    public override void OnLost()
    {
        base.OnLost();
        grabbing = false;
    }

    public override Color AimColor()
    {
        if (grabbing)
        {
            return Color.red;
        }
        else
        {
            return base.AimColor();
        }
    }

    public override string GetHint()
    {
        return "Grab";
    }
}

[System.Serializable]
public class Line
{
    public Transform a;
    public Transform b;

    public Line(Transform a, Transform b)
    {
        this.a = a;
        this.b = b;
    }
}

//public static class WallSlidingObjectGizmoDrawer
//{
//    [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
//    static void DrawGizmo(WallSlidingObject obj, GizmoType type)
//    {
//        Gizmos.color = Color.blue;
//        foreach (Line line in obj.rails)
//        {
//            Gizmos.DrawLine(line.a.position, line.b.position);
//        }
//    }
//}
