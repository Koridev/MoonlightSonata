using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFrame : Interactable, GrabListener
{
    private static Quaternion angleUp = Quaternion.Euler(new Vector3(0, 0, 0));
    private static Quaternion angleRight = Quaternion.Euler(new Vector3(90, 0, 0));
    private static Quaternion angleDown = Quaternion.Euler(new Vector3(180, 0, 0));
    private static Quaternion angleLeft = Quaternion.Euler(new Vector3(270, 0, 0));

    private static Quaternion[] angleSnaps = new Quaternion[] { angleUp, angleRight, angleDown, angleLeft };

    private void OnEnable()
    {
        cameraMovement.AddGrabListener(this);
    }

    private void OnDisable()
    {
        cameraMovement.RemoveGrabListener(this);
    }

    public override void OnDown(Vector3 hitPoint)
    {
        //Nothing to do
    }

    public override void OnUp()
    {
        //We shoud be holding the panel
        Quaternion rotation = cameraMovement.GetGrabbable().transform.rotation;

        float minAngle = float.MaxValue;
        Quaternion minQuaternion = Quaternion.identity;

        foreach(Quaternion q in angleSnaps)
        {
            float angle = Quaternion.Angle(rotation, q);
            if(angle < minAngle)
            {
                minAngle = angle;
                minQuaternion = q;
            }
        }

        (cameraMovement.GetGrabbable() as UnscrewablePanel).frame = this;
        cameraMovement.GetGrabbable().Release(transform.position, transform.rotation * minQuaternion);
        
    }

    public void OnGrab(GrabbableIdentifier id)
    {
        collider.enabled = id == GrabbableIdentifier.Panel;
    }

    public override string GetHint()
    {
        return "Attach";
    }
}
