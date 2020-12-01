using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable
{
    private bool open = false;

    public Transform openTransform;
    public Transform closeTransform;

    public AudioSource openCloseAudio;

    public override void OnDown(Vector3 hitPoint)
    {
        
    }

    public override void OnUp()
    {
        open = !open;

        if(openCloseAudio != null)
        {
            openCloseAudio.Play();
        }

        iTween.MoveTo(gameObject, iTween.Hash(
            "position", open? openTransform: closeTransform,
            "easeType", "linear", 
            "time", .5
        ));
    }

    public override string GetHint()
    {
        return open ? "Close" : "Open";
    }
}
