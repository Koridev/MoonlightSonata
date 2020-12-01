using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputActionsManager : MonoBehaviour
{
    private InputActions inputActions;

    private CameraMovement defaultListener;
    private Controller currentListener;

    public CursorController cursor;
    public InputHintController hintsController;

    private void Awake()
    {
        inputActions = new InputActions();
        defaultListener = GameObject.FindWithTag("Player").GetComponent<CameraMovement>();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus && enabled)
        {
            inputActions.Enable();
        }
        else
        {
            inputActions.Disable();
        }
    }

    private void OnEnable()
    {
        if (Application.isFocused)
        {
            inputActions.Enable();
        }
        
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void SetListener(Controller listener)
    {
        if(listener != null)
        {
            inputActions.Default.SetCallbacks(listener);
            currentListener = listener;
        }
        else
        {
            inputActions.Default.SetCallbacks(defaultListener);
            currentListener = defaultListener; 
        }

        RefreshInputHints();
    }

    private void Update()
    {
        if (currentListener != null)
        {
            cursor.SetUI(currentListener.IsAimingForSomething(), currentListener.GetTargetColor(), currentListener.GetCursorHint(), currentListener.ShowCursor());
        }
        else
        {
            cursor.SetUI(false, Color.white, "", false);
        }        
    }

    public void RefreshInputHints()
    {
        hintsController.SetHints(currentListener.GetInputHints());
    }

}

public interface Controller: InputActions.IDefaultActions
{
    bool IsAimingForSomething();
    Color GetTargetColor();
    string GetCursorHint();

    bool ShowCursor();

    List<(HintInputType, string)> GetInputHints();
}
