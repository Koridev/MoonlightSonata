using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverToMonitor : MonoBehaviour
{
    public LeverController lever;
    public MainMonitorController mainMonitor;

    public AudioSource failureAudio;

    public void OnLeverDown()
    {
        mainMonitor.TryRestart((result)=>{
            if (!result)
            {
                lever.PullBackUp();
                if(failureAudio != null)
                {
                    failureAudio.Play();
                }
                
            }
        });
        
    }
}
