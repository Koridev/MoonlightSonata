using UnityEngine;

public class TunnelDoor : Interactable
{
    private Transform character;

    public Transform destination;

    protected override void Awake()
    {
        base.Awake();
        character = cameraMovement.transform;
    }

    public override void OnDown(Vector3 hitPoint)
    {
    }

    public override void OnUp()
    {
        cameraMovement.DisableInteractions();
        iTween.MoveTo(character.gameObject, iTween.Hash("position", destination, "easeType", "linear", "speed", 3, "oncomplete", "onTunnelAnimationComplete", "oncompletetarget", gameObject));
    }

    private void onTunnelAnimationComplete()
    {
        cameraMovement.EnableInteractions();
    }

    public override string GetHint()
    {
        return "Go";
    }
}
