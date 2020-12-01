using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnscrewablePanel : AbstractGrabbable
{
    
    List<ScrewInteractable> screws;

    public PanelFrame frame;

    protected override void Awake()
    {
        base.Awake();
        screws = GetComponentsInChildren<ScrewInteractable>().ToList();
        foreach(ScrewInteractable screw in screws)
        {
            screw.SetCanScrew(frame != null);
        }
    }

    public override bool IsActive()
    {
        return base.IsActive() && screws.Select(a => a.unscrewed).Aggregate((a, b) => a && b);
    }

    protected override void OnGrab()
    {
        frame = null;
    }

    protected override void OnRelease()
    {  
        //nothing?
    }

    protected override Quaternion ReleaseRotation()
    {
        return cameraMovement.transform.rotation * Quaternion.Euler(0,90,0);
    }

    protected override void Update()
    {
        base.Update();
        foreach (ScrewInteractable screw in screws)
        {
            screw.SetCanScrew(frame != null);
        }
    }

    public override GrabbableIdentifier GetGrabbableIdentifier()
    {
        return GrabbableIdentifier.Panel;
    }
}
