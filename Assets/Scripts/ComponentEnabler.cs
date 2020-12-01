using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentEnabler : MonoBehaviour
{

    public bool startState;
    public Behaviour component;

    private bool currentState;
    private void Awake()
    {
        currentState = startState;
    }

    public void Switch()
    {
        currentState = !currentState;
    }

    private void Update()
    {
        component.enabled = currentState;
    }
}
