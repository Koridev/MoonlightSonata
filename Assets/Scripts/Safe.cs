using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    private bool open = false;

    private Vector3 closeRotation = Vector3.zero;
    private Vector3 openRotation = new Vector3(0, -170, 0);

    public AudioSource openAudio;
    

    public void SetOpen(bool open)
    {
        this.open = open;
        if (open)
        {
            iTween.RotateTo(gameObject, iTween.Hash("rotation", openRotation, "islocal", true, "easeType", "linear", "time", .5));
            openAudio.Play();
        }
        else
        {
            iTween.RotateTo(gameObject, iTween.Hash("rotation", closeRotation, "islocal", true, "easeType", "linear", "time", .5));
        }
    }
}
