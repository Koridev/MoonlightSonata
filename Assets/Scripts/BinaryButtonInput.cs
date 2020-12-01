using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryButtonInput : MonoBehaviour
{
    public BinaryButtonsManager manager;

    private void Update()
    {
        for(int i=1; i<10; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                manager.PressButton(i - 1);
            }
        }
    }
}
