using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioPowerButtonController : Interactable
{

    private float offAngle = 29.6f;
    private RadioBehaviour radio;
    private bool powered = false;

    protected override void Awake()
    {
        base.Awake();
        radio = GetComponentInParent<RadioBehaviour>();
    }

    public override void OnDown(Vector3 hitPoint)
    {
        radio.SwitchPower();
    }

    public override void OnUp()
    {
        //Nothing to do
    }

    public void SetPower(bool power)
    {
        powered = power;
        //transform.localEulerAngles = new Vector3(0, power? poweredAngle: 0f, 0);

        Vector3 localAngles = new Vector3(0, power ? 0f : offAngle, 0);
        iTween.RotateTo(gameObject, iTween.Hash("rotation", localAngles, "islocal", true, "time", 0.1f));
    }

    public override string GetHint()
    {
        return powered? "Turn off": "Turn on";
    }
}
