using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewInteractable : Interactable
{
    public bool unscrewed = false;

    private bool canScrew = false;

    private static float rotateValue = (360 * 4.3f);
    private static float moveValue = (0.1f);

    public AudioSource screwSound;

    public override void OnDown(Vector3 hitPoint)
    {
        //Nothing to do
    }

    public override void OnUp()
    {
        screwSound.Play();
        unscrewed = !unscrewed;
        if (unscrewed)
        {
            iTween.RotateAdd(gameObject, iTween.Hash("x", rotateValue, "easetype", "linear", "time", 1));
            iTween.MoveAdd(gameObject, iTween.Hash("x", moveValue, "easetype", "linear", "time", 1));
        }
        else
        {
            iTween.RotateAdd(gameObject, iTween.Hash("x", -rotateValue, "easetype", "linear", "time", 1));
            iTween.MoveAdd(gameObject, iTween.Hash("x", -moveValue, "easetype", "linear", "time", 1));
        }


        Debug.Log($"{gameObject.name} is screwed {!unscrewed}");
    }

    public void SetCanScrew(bool can)
    {
        canScrew = can;
    }

    public override bool IsActive()
    {
        return base.IsActive() && canScrew;
    }

    public override string GetHint()
    {
        return unscrewed ? "Screw" : "Unscrew";
    }
}
