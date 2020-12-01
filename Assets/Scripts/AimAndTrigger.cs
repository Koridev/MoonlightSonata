using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AimAndTrigger : MonoBehaviour
{

    private InputActionsManager inputActions;

    public CinemachineVirtualCamera camera;
    public float delayBeforeTrigger;
    public float delayBeforeRelease;
    public UnityEvent trigger;

    private static BlockedInputListener inputListener = new BlockedInputListener();

    private void Awake()
    {
        inputActions = GameObject.Find("InputManager").GetComponent<InputActionsManager>();
    }

    //TODO take control of input?
    public void OnSuccess()
    {
        StartCoroutine(Execute());
    }

    IEnumerator Execute()
    {
        inputActions.SetListener(inputListener);
        camera.Priority = 100;
        yield return new WaitForSeconds(delayBeforeTrigger);
        trigger?.Invoke();
        yield return new WaitForSeconds(delayBeforeRelease);
        camera.Priority = 0;

        inputActions.SetListener(null);
    }
}
