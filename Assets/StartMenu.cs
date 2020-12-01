using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartMenu : MonoBehaviour, Controller
{
    private CinemachineVirtualCamera virtualCamera;
    private InputActionsManager inputActionsManager;

    public MainMonitorController mainMonitor;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        inputActionsManager = GameObject.Find("InputManager").GetComponent<InputActionsManager>();
    }

    private void Start()
    {
        inputActionsManager.SetListener(this);
        mainMonitor.StartScreen();
    }

    public string GetCursorHint()
    {
        return "";
    }

    public List<(HintInputType, string)> GetInputHints()
    {
        return new List<(HintInputType, string)>() { (HintInputType.LMB, "Start") };
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
        if (context.performed)
        {
            mainMonitor.IntroError((result) => {
                virtualCamera.Priority = 0;
                inputActionsManager.SetListener(null);
            }, false);
        }
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
    }

    public void OnSpin(InputAction.CallbackContext context)
    {
    }

    public bool ShowCursor()
    {
        return false;
    }
}
