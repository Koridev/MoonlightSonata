using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static iTween;

public class LeverController : Interactable
{

    public Transform lever;
    public UnityEvent onPulled;

    private static readonly float angleUp = -20;
    private static readonly float angleDown = 50;

    private bool animComplete = false;
    private bool userUp = false;

    public AudioSource pullAudio;

    protected override void Awake()
    {
        base.Awake();
        lever.localEulerAngles = new Vector3(0,0,angleUp);
    }

    public override string GetHint()
    {
        return "Pull";
    }

    public override void OnDown(Vector3 hitPoint)
    {
        animComplete = false;
        userUp = false;

        pullAudio.Play();
        iTween.RotateTo(lever.gameObject, iTween.Hash("rotation", new Vector3(0,0,angleDown), "islocal", true, "easetype", EaseType.easeInSine, "time", 0.7f, "oncomplete", "OnLeverRotationComplete", "oncompletetarget", gameObject));
    }

    public override void OnUp()
    {
        userUp = true;
        TrySuccess();
    }

    private void OnLeverRotationComplete()
    {
        animComplete = true;
        TrySuccess();
    }

    private void TrySuccess()
    {
        if(userUp && animComplete)
        {
            onPulled.Invoke();
            animComplete = false;
            userUp = false;
        }
    }

    public void PullBackUp()
    {
        iTween.RotateTo(lever.gameObject, iTween.Hash("rotation", new Vector3(0, 0, angleUp), "islocal", true, "time", 0.3f));
    }
}
