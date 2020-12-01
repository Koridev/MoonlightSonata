using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : MonoBehaviour
{
    InputActionsManager inputActionsManager;
    private void Awake()
    {
        inputActionsManager = GameObject.Find("InputManager").GetComponent<InputActionsManager>();
    }
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
