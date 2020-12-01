using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Indicator))]
public class BinaryButton : MonoBehaviour
{
    public int index;
    private BinaryButtonsManager manager;
    private Indicator indicator;

    private void Awake()
    {
        manager = GetComponentInParent<BinaryButtonsManager>();
        indicator = GetComponent<Indicator>();
    }

    private void Update()
    {
        if(manager != null)
        {
            indicator.on = manager.GetLightState(index);
        }
        
    }
}
