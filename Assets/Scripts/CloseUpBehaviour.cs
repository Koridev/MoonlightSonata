using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class CloseUpBehaviour : MonoBehaviour, Controller
{
    private InputActionsManager inputActionsManager;
    private Action onBack;

    protected bool isActive = false;

    protected virtual void Awake()
    {
        inputActionsManager = GameObject.Find("InputManager").GetComponent<InputActionsManager>();
        if(inputActionsManager == null)
        {
            Debug.LogError("No inputActionsManager found");
        }
    }

    public abstract void OnInteractDown(InputAction.CallbackContext context);
    public abstract void OnInteractUp(InputAction.CallbackContext context);
    public abstract void OnLookX(InputAction.CallbackContext context);
    public abstract void OnLookY(InputAction.CallbackContext context);
    public abstract void OnSecondaryDown(InputAction.CallbackContext context);
    public abstract void OnSecondaryUp(InputAction.CallbackContext context);
    public abstract void OnSpin(InputAction.CallbackContext context);
    public abstract Color GetTargetColor();

    public abstract bool IsAimingForSomething();

    public virtual void Focus(Action onBack)
    {
        inputActionsManager.SetListener(this);
        this.onBack = onBack;
        isActive = true;
    }

    public virtual void Back()
    {
        isActive = false;
        inputActionsManager.SetListener(null);
        onBack?.Invoke();
    }

    public virtual bool IsActive()
    {
        return true;
    }

    public abstract string GetCursorHint();

    public List<(HintInputType, string)> GetInputHints()
    {
        return new List<(HintInputType, string)>() {
            (HintInputType.RMB, "Back")
        };
    }

    public bool ShowCursor()
    {
        return true;
    }

}
