using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour, Controller
{
    public float rotationFactor = 1;
    public float spinFactor = 1;

    private float x;
    private float y;
    private float z;

    private Interactable interactableFound;
    private AbstractGrabbable grabbing;

    private bool interactionsDisabled = false;

    private List<GrabListener> grabListeners;

    public AudioSource grabbingSound;

    RaycastHit hit;

    private InputActionsManager inputActionsManager;


    private void Awake()
    {
        inputActionsManager = GameObject.Find("InputManager").GetComponent<InputActionsManager>();
        grabListeners = new List<GrabListener>();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void AddGrabListener(GrabListener listener)
    {
        if (!grabListeners.Contains(listener))
        {
            grabListeners.Add(listener);
        }
        
    }

    public void RemoveGrabListener(GrabListener listener)
    {
        grabListeners.Remove(listener);
    }

    public void OnLookX(InputAction.CallbackContext context)
    {
        x = context.ReadValue<float>() * rotationFactor;
    }

    public void OnLookY(InputAction.CallbackContext context)
    {
        y = context.ReadValue<float>() * rotationFactor;
    }

    public void OnInteractDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactableFound?.OnDown(hit.point);
        }
    }

    public void OnInteractUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactableFound?.OnUp();
        }
    }

    public void OnSpin(InputAction.CallbackContext context)
    {
        z = context.ReadValue<float>() * spinFactor;
    }

    public string GetCursorHint()
    {
        return (interactableFound != null)? interactableFound.GetHint(): "";
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, 1 << LayerMask.NameToLayer("Default")))
        {
            if (interactionsDisabled)
            {
                if (interactableFound != null)
                {
                    interactableFound.OnLost();
                }
                interactableFound = null;
            }
            else
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null && interactable.IsActive())
                {
                    if (interactableFound != null && interactableFound != interactable)
                    {
                        interactableFound.OnLost();
                    }
                    interactableFound = interactable;
                }
                else
                {
                    if (interactableFound != null)
                    {
                        interactableFound.OnLost();
                    }
                    interactableFound = null;
                }
            }
        }
        else
        {
            if (interactableFound != null)
            {
                interactableFound.OnLost();
            }
            interactableFound = null;
        }

        

        if (interactableFound != null && interactableFound.Process(transform, new Vector3(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime)))
        {
            //Nothing?
        }
        else
        {
            transform.Rotate(y * Time.deltaTime, x * Time.deltaTime, z * Time.deltaTime);
        }

        interactableFound?.Hover();
    }

    public void OnSecondaryDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (grabbing != null && !interactionsDisabled)
            {
                grabbing.OnSecondaryDown();
            }
        }
        
    }

    public void OnSecondaryUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (grabbing != null && !interactionsDisabled)
            {
                grabbing.OnSecondaryUp();
            }
        }
    }

    public Color GetTargetColor()
    {
        return (interactableFound != null) ? interactableFound.AimColor() : Color.white;
    }

    public bool IsAimingForSomething()
    {
        return (interactableFound != null);
    }

    public void SetGrabbing(AbstractGrabbable grabbable)
    {
        if (grabbing != null && grabbable != null)
        {
            throw new UnityException($"Trying to grab {grabbable.gameObject.name} while grabbing {grabbing.gameObject.name}");
        }
        this.grabbing = grabbable;
        inputActionsManager.RefreshInputHints();
    }

    public bool IsGrabbing()
    {
        return grabbing != null;
    }

    public bool IsGrabbing(GrabbableIdentifier id)
    {
        return grabbing != null && grabbing.GetGrabbableIdentifier() == id;
    }

    public AbstractGrabbable GetGrabbable()
    {
        return grabbing;
    }

    public void DisableInteractions()
    {
        interactionsDisabled = true;
    }

    public void EnableInteractions()
    {
        interactionsDisabled = false;
    }

    public List<(HintInputType, string)> GetInputHints()
    {
        if (IsGrabbing())
        {
            return new List<(HintInputType, string)>() {
            (HintInputType.RMB, "Release"), (HintInputType.Q, "Left spin"), (HintInputType.E, "Right spin")
        };
        }
        else
        {
            return new List<(HintInputType, string)>() {
            (HintInputType.Q, "Left spin"), (HintInputType.E, "Right spin")
        };
        }
        
    }

    public AudioSource GrabbingAudioSource()
    {
        return grabbingSound;
    }

    public bool ShowCursor()
    {
        return true;
    }
}

public interface SecondaryListener
{
    void OnSecondaryUp();

    void OnSecondaryDown();
}

public interface GrabListener
{
    void OnGrab(GrabbableIdentifier id);
}
