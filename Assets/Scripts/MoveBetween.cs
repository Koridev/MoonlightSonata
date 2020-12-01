using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    public Transform start;
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = start.position;
        Vector3 amount = destination.position - start.position;
        iTween.MoveTo(gameObject, iTween.Hash("position", destination.localPosition, "islocal", true, "easeType", "linear", "time", 5, "oncomplete", "onTweenComplete", "oncompletetarget", gameObject));
    }

    public void onTweenComplete()
    {
        Debug.Log($"TweenComplete {transform.localPosition}");
    }



}
