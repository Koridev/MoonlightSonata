using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockedInputListener : Controller
{
    public string GetCursorHint()
    {
        return "";
    }

    public List<(HintInputType, string)> GetInputHints()
    {
        return new List<(HintInputType, string)>();
    }

    public Color GetTargetColor()
    {
        return Color.white;
    }

    public bool IsAimingForSomething()
    {
        return false;
    }

    public void OnInteractDown(InputAction.CallbackContext context)
    {
        
    }

    public void OnInteractUp(InputAction.CallbackContext context)
    {
        
    }

    public void OnLookX(InputAction.CallbackContext context)
    {
        
    }

    public void OnLookY(InputAction.CallbackContext context)
    {
        
    }

    public void OnSecondaryDown(InputAction.CallbackContext context)
    {
        
    }

    public void OnSecondaryUp(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSpin(InputAction.CallbackContext context)
    {
        
    }

    public bool ShowCursor()
    {
        return false;
    }
}
