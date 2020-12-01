using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Grabbable : AbstractGrabbable
{
    public UnityEvent onGrab;
    public UnityEvent onRelease;

    public GrabbableIdentifier identifier;

    public override GrabbableIdentifier GetGrabbableIdentifier()
    {
        return identifier;
    }

    protected override void OnGrab()
    {
        onGrab?.Invoke();
    }

    protected override void OnRelease()
    {
        onRelease?.Invoke();
    }
}
