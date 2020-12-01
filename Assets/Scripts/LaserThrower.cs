using Shapes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserThrower : MonoBehaviour
{
    LineRenderer line;
    RaycastHit hit;

    List<Vector3> points;
    public AudioSource powerOnAudio;
    public AudioSource beamStart;
    public AudioSource beamAudio;

    public bool on;

    private static CloseEnoughVector3 closeEnough = new CloseEnoughVector3();

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        points = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {

        beamAudio.mute = !on;

        points.Clear();

        if (on)
        {
            FillPoints(transform.position, transform.forward, points);
            line.positionCount = points.Count;
        }
        
        line.SetPositions(points.ToArray());
    }

    private void FillPoints(Vector3 startingPoint, Vector3 direction, List<Vector3> points)
    {
        points.Add(startingPoint);
        if(points.Count > 20)
        {
            return;
        }
        if (Physics.Raycast(startingPoint, direction, out hit, float.MaxValue, LayerMask.GetMask(new string[2] { "Wall", "Mirror"})))
        {
            
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Mirror"))
            {

                if (points.Contains<Vector3>(hit.point, closeEnough))
                {
                    points.Add(hit.point);
                }
                else
                {
                    FillPoints(hit.point, hit.normal, points);
                }
            }
            else
            {
                if (hit.collider.CompareTag("Target"))
                {
                    hit.collider.gameObject.GetComponent<LaserTargetController>().Power();
                }
                else
                {
                    Debug.Log("laser hits "+ hit.collider.gameObject.name);
                }
                points.Add(hit.point);
                //TODO add laser collision effect
            }
        }
        else
        {
            points.Add(startingPoint + direction * 10);

        }
    }

    public void TurnOn()
    {
        StartCoroutine(TurnOnAsync());
        
    }

    IEnumerator TurnOnAsync()
    {
        powerOnAudio.Play();
        yield return new WaitForSeconds(2.1f);
        beamStart.Play();
        on = true;
    }
}

class CloseEnoughVector3 : IEqualityComparer<Vector3>
{
    public bool Equals(Vector3 x, Vector3 y)
    {
        return x == y;
    }

    public int GetHashCode(Vector3 obj)
    {
        return obj.GetHashCode();
    }
}
