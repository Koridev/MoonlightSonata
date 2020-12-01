using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLookAt : MonoBehaviour
{
    public Transform container;
    public float speed;
    public bool goingLeft;

    public List<Vector3> movements;
    Quaternion rotationOffset = new Quaternion();

    List<Line> lines;

    private void Awake()
    {
        transform.LookAt(Vector3.zero); 

        if(container != null)
        {
            lines = new List<Line>();

            if (container.childCount > 1)
            {
                for (int i = 1; i < container.childCount; i++)
                {
                    lines.Add(new Line(container.GetChild(i - 1), container.GetChild(i)));
                }

                lines.Add(new Line(container.GetChild(container.childCount - 1), container.GetChild(0)));
            }
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    foreach(Vector3 movement in movements)
        //    {
        //        transform.position = transform.position + movement;
        //        rotationOffset.SetFromToRotation(transform.forward * 2, (transform.forward * 2) - movement);
        //        transform.rotation = rotationOffset * transform.rotation;
        //    }
           
        //}


    }
}
