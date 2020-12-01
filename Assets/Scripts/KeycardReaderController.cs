using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeycardReaderController : Interactable
{
    public UnityEvent onSuccess;

    public AudioSource successAudio;

    public Transform contactPosition;

    public Transform releasePosition;

    private AbstractGrabbable grabbable;

    private static BlockedInputListener inputListener = new BlockedInputListener();

    private InputActionsManager inputActions;

    protected override void Awake()
    {
        base.Awake();
        inputActions = GameObject.Find("InputManager").GetComponent<InputActionsManager>();
    }

    public override string GetHint()
    {
        return "Use";
    }

    public override void OnDown(Vector3 hitPoint)
    {
        inputActions.SetListener(inputListener);
        grabbable = cameraMovement.GetGrabbable();
        iTween.MoveTo(grabbable.gameObject, iTween.Hash("position", contactPosition.position, "easeType", "linear", "time", .5, "oncomplete", "onTweenComplete", "oncompletetarget", gameObject));
        iTween.RotateTo(grabbable.gameObject, iTween.Hash("rotation", contactPosition.eulerAngles, "easeType", "linear", "time", .3));
    }

    private void onTweenComplete()
    {
        if (successAudio != null)
        {
            successAudio.Play();
        }

        StartCoroutine(ExecuteSuccess());
    }

    public override void OnUp()
    {
        // Nothing to do
    }

    IEnumerator ExecuteSuccess()
    {
        

        Color startColor = meshRenderer.materials[1].color;
        Color endColor = new Color(0, 0.8784314f, 0.5372549f);

        float time = 0f;

        while(time < 0.1f)
        {
            meshRenderer.materials[1].color = Color.Lerp(startColor, endColor, time / 0.1f);
            yield return null;
            time += Time.deltaTime;
        }

        yield return new WaitForSeconds(0.3f);

        onSuccess.Invoke();
        grabbable.Release(releasePosition.position, releasePosition.rotation);
    }

}
