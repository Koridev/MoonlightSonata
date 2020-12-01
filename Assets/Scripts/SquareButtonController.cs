using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareButtonController : Interactable
{

    public ColoredButtonType type;
    private ColoredButtonPuzzle manager;

    public AudioSource keyDownAudio;
    public AudioSource inputAudio;

    private bool isDown = false;

    protected override void Awake()
    {
        base.Awake();
        manager = GetComponentInParent<ColoredButtonPuzzle>();
    }

    public override string GetHint()
    {
        return "Press";
    }

    public override void OnDown(Vector3 hitPoint)
    {
        isDown = true;
        if (keyDownAudio != null)
        {
            keyDownAudio?.Play();
        }
        iTween.MoveTo(gameObject, iTween.Hash("y", -0.0559, "islocal", true, "easeType", "linear", "time", 0.1f));
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
        iTween.MoveTo(gameObject, iTween.Hash("y", -0.04003357f, "islocal", true, "easeType", "linear", "time", 0.1f));

        manager.AddInput(type);
        isDown = false;
       
    }

    public override void OnUp()
    {
        Release();
    }

    


}
