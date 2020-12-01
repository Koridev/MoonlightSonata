using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioModeButtonController : Interactable
{
    public RadioMode mode;
    public Vector3 pressedOffset = new Vector3(0.05f,0,0);

    private RadioBehaviour radio;
    private Vector3 initialPosition;

    public AudioSource onDownAudio;
    public AudioSource onUpAudio;

    private bool currentPressed = false;

    protected override void Awake()
    {
        base.Awake();
        radio = GetComponentInParent<RadioBehaviour>();
        initialPosition = transform.localPosition;
    }

    public void SetPressed(bool pressed)
    {
        if(currentPressed != pressed)
        {
            Vector3 localPosition = pressed ? (initialPosition + pressedOffset) : initialPosition;
            iTween.MoveTo(gameObject, iTween.Hash("position", localPosition, "islocal", true, "time", 0.1f));
            if (pressed)
            {
                onDownAudio.Play();
            }
            else
            {
                onUpAudio.Play();
            }
        }

        currentPressed = pressed;
    }

    public override void OnDown(Vector3 hitPoint)
    {
        radio.SetMode(mode);
        
    }

    public override void OnUp()
    {
    }

    public override string GetHint()
    {
        return "Press";
    }
}
