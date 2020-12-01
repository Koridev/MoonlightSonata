using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class CursorControllingBehaviour : CloseUpBehaviour
{
    protected RectTransform cursor;

    private float x, y;

    public float factor = 200;

    protected RaycastHit hit;
    protected Interactable foundInteractable;
    protected Transform character;

    float minX = -1920 * 0.5f;
    float maxX = 1920 * 0.5f;

    float minY = -1080 * 0.5f;
    float maxY = 1080 * 0.5f;

    protected override void Awake()
    {
        base.Awake();
        character = GameObject.FindWithTag("Player").transform;

        Transform space = GameObject.FindWithTag("TestTag").transform;

        cursor = GameObject.FindWithTag("Cursor").GetComponent<RectTransform>();

        if (cursor == null)
        {
            Debug.LogError("GameObject with tag Cursor was not found");
        }
    }

    public override string GetCursorHint()
    {
        return foundInteractable?.GetHint() ?? "";
    }

    protected virtual void Update()
    {
        if (isActive && cursor != null)
        {
            float newX = cursor.anchoredPosition.x + x * Time.deltaTime * factor;
            newX = Mathf.Clamp(newX, minX, maxX);

            float newY = cursor.anchoredPosition.y + y * Time.deltaTime * factor;
            newY = Mathf.Clamp(newY, minY, maxY);

            cursor.anchoredPosition = new Vector2(newX, newY);
            Rect screenRect = Utils.GetScreenCoordinates(cursor);
            

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(screenRect.center.x, screenRect.center.y, 0f));
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << GetClickableLayer()))
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();
                if (newInteractable != foundInteractable)
                {
                    foundInteractable?.OnLost();
                }
                foundInteractable = newInteractable;
            }
            else
            {
                if(foundInteractable != null)
                {
                    foundInteractable.OnLost();
                }
                foundInteractable = null;
            }

            foundInteractable?.Hover();
        }
    }

    public override void Back()
    {
        foundInteractable?.OnLost();
        cursor.anchoredPosition = new Vector2(0, 0);
        base.Back();
    }

    public override void OnInteractDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (foundInteractable != null)
            {
                foundInteractable.OnDown(hit.point);
            }
        }
    }

    public override void OnInteractUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (foundInteractable != null)
            {
                foundInteractable.OnUp();
            }
        }
    }

    public override void OnLookX(InputAction.CallbackContext context)
    {
        x = context.ReadValue<float>();
    }

    public override void OnLookY(InputAction.CallbackContext context)
    {
        y = -context.ReadValue<float>();
    }

    public override void OnSecondaryDown(InputAction.CallbackContext context)
    {
        //Nothing to do
    }

    public override void OnSecondaryUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Back();
        }
    }

    public override void OnSpin(InputAction.CallbackContext context)
    {
        //Noting to do
    }

    public override Color GetTargetColor()
    {
        return foundInteractable != null ? Interactable.INTERACTION_COLOR : Color.white;
    }

    public override bool IsAimingForSomething()
    {
        return foundInteractable != null;
    }

    public abstract LayerMask GetClickableLayer();
}
