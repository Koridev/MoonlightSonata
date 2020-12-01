using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rail))]
public class RailGenerator : MonoBehaviour
{

    Rail rail;
    void Awake()
    {
        rail = GetComponent<Rail>();   
    }

    private void OnEnable()
    {
        if(transform.childCount >= 2)
        {
            Transform leftTip = transform.GetChild(0);
            Transform rightTip = transform.GetChild(1);

            //rail.left = leftTip.position;
            //rail.right = rightTip.position;
        }
        
    }


}
