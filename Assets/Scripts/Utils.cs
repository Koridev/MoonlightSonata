using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Utils
{
    public static float SHUTTER_RADIUS = 2f;

    public static Vector3 PositionOnWall(Quaternion positionOnSphere)
    {
        return positionOnSphere * Vector3.forward * SHUTTER_RADIUS;
    }

    public static Vector3 NearestPointOnLine(Vector3 linePnt, Vector3 lineDir, Vector3 pnt)
    {
        lineDir.Normalize();//this needs to be a unit vector
        var v = pnt - linePnt;
        var d = Vector3.Dot(v, lineDir);
        return linePnt + lineDir * d;
    }


    public static Vector3 NearestPointOnSegment(Vector3 point, Vector3 A, Vector3 B)
    {
        Vector3 np = NearestPointOnLine(A, B - A, point);
        float AtoPDist = Vector3.Distance(A, np);
        float BtoPDist = Vector3.Distance(B, np);
        float segmentLength = Vector3.Distance(A, B);

        if (BtoPDist >= segmentLength && AtoPDist < BtoPDist)
        {
            return A;
        }
        else if (AtoPDist >= segmentLength && BtoPDist < AtoPDist)
        {
            return B;
        }

        return np;

    }

    public static Rect GetScreenCoordinates(RectTransform uiElement)
    {
        var worldCorners = new Vector3[4];
        uiElement.GetWorldCorners(worldCorners);
        var result = new Rect(
                      worldCorners[0].x,
                      worldCorners[0].y,
                      worldCorners[2].x - worldCorners[0].x,
                      worldCorners[2].y - worldCorners[0].y);
        return result;
    }
}
