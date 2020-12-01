using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RadioKnobController : Interactable
{
    private bool isClicked = false;

    public float maxAngle;

    public override string GetHint()
    {
        return "Turn the knob";
    }

    public override void OnDown(Vector3 hitPoint)
    {
        isClicked = true;
    }

    public override void OnUp()
    {
        isClicked = false;
    }

    public override void OnLost()
    {
        base.OnLost();
        isClicked = false;
    }

    public void SetFrequency(float frequency)
    {
        float angle = Mathf.Lerp(-maxAngle, maxAngle, 1 - frequency);
        transform.localEulerAngles = new Vector3(angle, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    public bool IsClicked()
    {
        return isClicked;
    }
}
