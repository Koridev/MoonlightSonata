using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    //public Vector3 right;
    //public Vector3 left;

    //public Vector3 tangent;

    //public List<Rail> startConnected;
    //public List<Rail> endConnected;

    public float radius = 2f;
    public float angle = 90f;

    

    private Vector3 center
    {
        get
        {
            return transform.position + transform.forward * radius;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.blue;
        //Vector3 startTangent = left - transform.position;
        //Debug.Log($"Start tangent {startTangent}");
        //Vector3 endTangent = right - transform.position;
        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(left, left+startTangent);
        //Handles.DrawBezier(right, left, right + tangent, left + tangent, Color.green, null, 2f);

        //Handles.color = Color.blue;
        //Handles.DrawWireArc(center, transform.up, -transform.forward, angle , radius);
    }

    public void MoveAt(Transform attached, float position)
    {
        float angleOffset = angle * position;
        attached.position = transform.position;
        attached.rotation = transform.rotation;
        attached.RotateAround(center, transform.up, angleOffset);

    }
}
