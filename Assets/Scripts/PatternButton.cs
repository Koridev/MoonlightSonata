using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternButton : MonoBehaviour
{
    public int index;
    public Transform button;

    private float releasePosition = 0.04131475f;
    private float pressedPosition = -0.074f;

    private BinaryButtonsManager manager;

    private bool isPressed = false;

    private void Awake()
    {
        manager = GetComponentInParent<BinaryButtonsManager>();
    }

    public void OnPress()
    {
        isPressed = true;
        manager?.PressButton(index);
        iTween.MoveTo(button.gameObject, iTween.Hash("y", pressedPosition, "islocal", true, "easeType", "linear", "time", 0.1f));
    }

    public void OnRelease()
    {
        if (isPressed)
        {
            iTween.MoveTo(button.gameObject, iTween.Hash("y", releasePosition, "islocal", true, "easeType", "linear", "time", 0.1f));
        }
        isPressed = false;
    }

    public List<bool> GetPattern()
    {
        return manager?.GetButtonEffect(index);
    }

}
