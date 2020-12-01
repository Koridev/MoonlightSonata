using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrabbableIdentifier
{
    None, Panel, Screwdriver, Keycard
}
public abstract class AbstractGrabbable : Interactable, SecondaryListener
{
    public Transform initialTransform;
    public float releaseDistance = 0.7f;

    private GameObject character;

    protected bool isGrabbed = false;

    private Transform releasedParent;

    protected override void Awake()
    {
        base.Awake();
        character = GameObject.FindWithTag("Player");
        releasedParent = GameObject.FindWithTag("SpaceStation").transform;
    }

    public override void OnDown(Vector3 hitPoint)
    {
        //Nothing to do
    }

    public override string GetHint()
    {
        return "Grab";
    }

    public override void OnUp()
    {
        if (!cameraMovement.IsGrabbing())
        {
            cameraMovement.GrabbingAudioSource().Play();
            transform.SetParent(character.transform);

            iTween.MoveTo(gameObject, iTween.Hash("position", initialTransform.localPosition, "islocal", true, "easeType", "linear", "time", .5, "oncomplete", "onTweenComplete", "oncompletetarget", gameObject));
            iTween.RotateTo(gameObject, iTween.Hash("rotation", initialTransform.localEulerAngles, "islocal", true, "easeType", "linear", "time", .5));
        }
    }

    private void onTweenComplete()
    {
        cameraMovement.SetGrabbing(this);
        transform.rotation = initialTransform.rotation;
        isGrabbed = true;
        OnGrab();
    }

    public void Release(Vector3 position, Quaternion rotation)
    {
        transform.SetParent(releasedParent);

        cameraMovement.SetGrabbing(null);
        OnRelease();
        isGrabbed = false;

        iTween.MoveTo(gameObject, iTween.Hash("position", position, "easeType", "linear", "time", 0.5f));
        iTween.RotateTo(gameObject, iTween.Hash("rotation", rotation.eulerAngles, "easeType", "linear", "time", 0.3f));

    }

    public void OnSecondaryUp()
    {
        
        Release(ReleasePosition(), ReleaseRotation());
    }

    public void OnSecondaryDown()
    {

    }

    protected virtual Vector3 ReleasePosition()
    {
        return cameraMovement.transform.position + (cameraMovement.transform.forward * releaseDistance);
    }

    protected virtual Quaternion ReleaseRotation() {
        return transform.rotation;
    }

    protected abstract void OnGrab();
    protected abstract void OnRelease();

    public abstract GrabbableIdentifier GetGrabbableIdentifier();

    public override bool IsActive()
    {
        return base.IsActive() && !isGrabbed && !cameraMovement.IsGrabbing();
    }
}
