using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : Interactable
{
    public UnityEvent onDown;
    public UnityEvent onUp;
    public UnityEvent onLost;

    public AudioSource downAudio;
    public AudioSource upAudio;

    public override void OnDown(Vector3 hitPoint)
    {
        if(downAudio != null)
        {
            downAudio.Play();
        }
        onDown?.Invoke();
    }

    public override void OnUp()
    {
        if (upAudio != null)
        {
            upAudio.Play();
        }
        onUp?.Invoke();
    }

    public override void OnLost()
    {
        base.OnLost();
        onLost?.Invoke();
    }

    public override string GetHint()
    {
        return "Click";
    }
}
