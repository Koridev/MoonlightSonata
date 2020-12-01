using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableNumpadKey : Interactable
{
    public int index;
    private NumpadBehaviour numpad;

    public AudioSource keyDownAudio;
    public AudioSource inputAudio;

    private bool isDown = false;

    protected override void Awake()
    {
        base.Awake();
        numpad = GetComponentInParent<NumpadBehaviour>();
    }

    public override void OnDown(Vector3 hitPoint)
    {
        isDown = true;
        numpad.Append(index);
        if(keyDownAudio != null)
        {
            keyDownAudio?.Play();
        }
        iTween.MoveTo(gameObject, iTween.Hash("y", 0.044, "islocal", true, "easeType", "linear", "time", 0.1f));
    }

    public override void OnUp()
    {
        Release();
        
    }

    public override void OnLost()
    {
        base.OnLost();
        if (isDown)
        {
            Release();
        }
        
    }

    private void Release()
    {
        if (inputAudio != null)
        {
            inputAudio.Play();
        }
        iTween.MoveTo(gameObject, iTween.Hash("y", 0.07618435, "islocal", true, "easeType", "linear", "time", 0.1f));
        isDown = false;
    }

    public override string GetHint()
    {
        return "Click";
    }
}
