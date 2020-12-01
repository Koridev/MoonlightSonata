using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTargetController : MonoBehaviour
{
    public MeshRenderer laserMesh;
    public Light poweredLight;
    public float maxIntensity = 2;
    private float timeToMaxIntensity = 3.42f;
    private float timeToMinIntensity = 0.5f;

    public AudioSource powerOnAudio;

    public TargetStateListener listener;

    private bool isCharging = false;
    private bool isPoweredThisFrame;
    private bool isFullyCharged = false;

    public void Power()
    {
        isPoweredThisFrame = true;
        
    }

    private void LateUpdate()
    {
        if(isCharging != isPoweredThisFrame)
        {
            isCharging = isPoweredThisFrame;
            
            if (isCharging)
            {
                double time = (poweredLight.intensity / maxIntensity) * powerOnAudio.clip.length;
                Debug.Log($"Start power audio at {time}");
                powerOnAudio.PlayScheduled(time);
            }
            else
            {
                powerOnAudio.Stop();
                isFullyCharged = false;
                if (listener != null)
                {
                    listener.OnStateChange(isFullyCharged);
                }

            }
        }
        if (isCharging)
        {
            if (poweredLight.intensity < maxIntensity)
            {
                poweredLight.intensity += maxIntensity * (Time.deltaTime / timeToMaxIntensity);
            }
            else if(poweredLight.intensity >= maxIntensity && !isFullyCharged)
            {
                isFullyCharged = true;
                listener.OnStateChange(isCharging);
            }
        }
        else
        {
            if (poweredLight.intensity > 0)
            {
                poweredLight.intensity -= maxIntensity * (Time.deltaTime / timeToMinIntensity);
            }
        }
        
       
        
        isPoweredThisFrame = false;
    }

    public bool IsPoweredOn()
    {
        return isCharging;
    }

    private void Update()
    {
        //if (isOn)
        //{
        //    laserMesh.material = onMaterial;
        //}
        //else
        //{
        //    laserMesh.material = offMaterial;
        //}
    }
}

public interface TargetStateListener
{
    void OnStateChange(bool state);
}
