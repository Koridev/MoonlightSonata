using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CloseUpInteractable : Interactable
{

    public CinemachineVirtualCamera camera;
    public CloseUpBehaviour behaviour;

    protected bool isFocus = false;

    public override void OnDown(Vector3 hitPoint)
    {
        //Nothing to do
    }

    public override void OnUp()
    {
        TakeFocus();
    }

    private void TakeFocus()
    {
        isFocus = true;
        camera.Priority = 100;
        OnLost();
        behaviour.Focus(() => {
            isFocus = false;
            camera.Priority = 0;
        });
    }

    public override bool IsActive()
    {
        return base.IsActive() && (behaviour?.IsActive() ?? true);
    }

    public override string GetHint()
    {
        return "Look at";
    }

    protected override bool CanHighlight()
    {
        return !isFocus;
    }
}
