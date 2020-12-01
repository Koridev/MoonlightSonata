using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMonitorController : MonoBehaviour, Controller, TargetStateListener
{
    public CinemachineVirtualCamera camera;
    public LaserTargetController target;
    private InputActionsManager inputActions;
    private Material screenMaterial;

    public RadioBehaviour radio;

    public Texture blinkOffTexture;

    public List<Texture> startTextures;

    public Texture introError;

    public Texture defaultTexture;
    public Texture errorTexture;

    public Texture poweredUpTexture;
    //public Texture successTexture;
    public List<Texture> successTextures;

    public AudioSource bipSound;
    public AudioSource errorSound;
    public AudioSource introErrorSound;
    public AudioSource engineStartSound;
    public AudioSource engineLoopSound;
    public AudioSource endingSound;

    private bool isPowered = false;
    private IEnumerator startScreenLoop;

    private void Awake()
    {
        inputActions = GameObject.Find("InputManager").GetComponent<InputActionsManager>();
        screenMaterial = GetComponent<MeshRenderer>().materials[1];

        target.listener = this;
    }

    public void StartScreen()
    {
        startScreenLoop = StartScreenCoroutine();
        StartCoroutine(startScreenLoop);
    }

    IEnumerator StartScreenCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < startTextures.Count; i++)
            {
                yield return new WaitForSeconds(0.4f);
                if(i%2 == 0)
                {
                    bipSound.Play();
                }
                SetTexture(startTextures[i]);
            }
        }
    }

    public void IntroError(Action<bool> callback, bool focusCamera = true)
    {
        if (startScreenLoop != null)
        {
            StopCoroutine(startScreenLoop);
            startScreenLoop = null;
        }

        StartCoroutine(IntroErrorCoroutine(callback, focusCamera));
    }

    public void TryRestart(Action<bool> callback, bool focusCamera = true)
    {
        if(startScreenLoop != null)
        {
            StopCoroutine(startScreenLoop);
            startScreenLoop = null;
        }
        
        if (target.IsPoweredOn())
        {
            StartCoroutine(Success(callback, focusCamera));
        }
        else
        {
            StartCoroutine(Error(callback, focusCamera));
        }
        
    }

    IEnumerator TargetOff()
    {
        SetTexture(defaultTexture);
        yield return null;
    }

    IEnumerator TargetOn()
    {
        SetTexture(poweredUpTexture);
        yield return null;
    }

    private void SetTexture(Texture tex)
    {
        screenMaterial.SetTexture("_MainTex", tex);
    }

    IEnumerator Success(Action<bool> callback, bool focusCamera)
    {
        if (focusCamera)
        {
            camera.Priority = 100;
        }

        radio.SwitchPower();

        float length = engineStartSound.clip.length;
        engineStartSound.Play();
        engineLoopSound.PlayDelayed(length);

        inputActions.SetListener(this);

        yield return new WaitForSeconds(0.3f);

        SetTexture(successTextures[0]);
        yield return new WaitForSeconds(1f);

        for(int i=1; i < 5; i++)
        {
            for(int j=0; j < 2; j++)
            {
                SetTexture(successTextures[i]);
                yield return new WaitForSeconds(0.4f);
                bipSound.Play();
                SetTexture(blinkOffTexture);
                yield return new WaitForSeconds(0.4f);
            }
            
        }


        SetTexture(successTextures[5]);
        yield return new WaitForSeconds(3f);

        SetTexture(successTextures[6]);
        yield return new WaitForSeconds(3f);

        SetTexture(successTextures[7]);
        yield return new WaitForSeconds(3f);

        SetTexture(successTextures[8]);
        endingSound.Play();
        yield return new WaitForSeconds(0.2f);


        callback.Invoke(true);
    }

    
    IEnumerator IntroErrorCoroutine(Action<bool> callback, bool focusCamera)
    {
        if (focusCamera)
        {
            camera.Priority = 100;
        }
        inputActions.SetListener(this);

        yield return new WaitForSeconds(0.4f);

        //errorSound.Play();
        introErrorSound.Play();

        SetTexture(introError);

        yield return new WaitForSeconds(1.2f);

        SetTexture(defaultTexture);

        camera.Priority = 0;
        yield return new WaitForSeconds(0.2f);

        inputActions.SetListener(null);
        callback.Invoke(false);
    }

    IEnumerator Error(Action<bool> callback, bool focusCamera)
    {
        if (focusCamera)
        {
            camera.Priority = 100;
        }
        inputActions.SetListener(this);

        yield return new WaitForSeconds(0.4f);

        errorSound.Play();

        SetTexture(errorTexture);

        yield return new WaitForSeconds(1.2f);

        SetTexture(defaultTexture);

        camera.Priority = 0;
        yield return new WaitForSeconds(0.2f);

        inputActions.SetListener(null);
        callback.Invoke(false);
    }

    public bool IsAimingForSomething()
    {
        return false;
    }

    public Color GetTargetColor()
    {
        return Color.white;
    }

    public string GetCursorHint()
    {
        return "";
    }

    public List<(HintInputType, string)> GetInputHints()
    {
        return new List<(HintInputType, string)>();
    }

    public void OnInteractDown(InputAction.CallbackContext context)
    {
        
    }

    public void OnInteractUp(InputAction.CallbackContext context)
    {
        
    }

    public void OnLookX(InputAction.CallbackContext context)
    {
        
    }

    public void OnLookY(InputAction.CallbackContext context)
    {
        
    }

    public void OnSpin(InputAction.CallbackContext context)
    {
        
    }

    public void OnSecondaryDown(InputAction.CallbackContext context)
    {
        
    }

    public void OnSecondaryUp(InputAction.CallbackContext context)
    {
        
    }

    public void OnStateChange(bool state)
    {
        if(startScreenLoop == null)
        {
            this.isPowered = state;
            if (isPowered)
            {
                StartCoroutine(TargetOn());
            }
            else
            {
                StartCoroutine(TargetOff());
            }
        }
        
    }

    public bool ShowCursor()
    {
        return false;
    }
}
