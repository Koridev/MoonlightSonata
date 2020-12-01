using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NumpadBehaviour : CursorControllingBehaviour
{
    public int password1;
    public int password2;
    public int password3;

    public UnityEvent onSuccess;

    private List<int> insertedKeys;

    private Texture screenEmtpy;
    private Texture screenInput1;
    private Texture screenInput2;
    private Texture screenInput3;
    private Texture screenError;

    private Material screenMaterial;

    private bool passwordSuccess = false;
    private bool showingError = false;

    public AudioSource successAudio;
    public AudioSource errorAudio;

    public override LayerMask GetClickableLayer()
    {
        return LayerMask.NameToLayer("Numpad");
    }

    protected override void Awake()
    {
        base.Awake();
        insertedKeys = new List<int>();
        screenEmtpy = Resources.Load<Texture>("Textures/Numpad_Screen/numpad_empty");
        screenInput1 = Resources.Load<Texture>("Textures/Numpad_Screen/numpad_input_1");
        screenInput2 = Resources.Load<Texture>("Textures/Numpad_Screen/numpad_input_2");
        screenInput3 = Resources.Load<Texture>("Textures/Numpad_Screen/numpad_input_3");
        screenError = Resources.Load<Texture>("Textures/Numpad_Screen/numpad_err");

        screenMaterial = GetComponent<MeshRenderer>().materials[1];

        UpdateScreen();
    }

    public void Append(int key)
    {
        if(insertedKeys.Count < 3 && !showingError)
        {
            insertedKeys.Add(key);
            if (insertedKeys.Count == 3)
            {
                //Check inserted password
                if (insertedKeys[0] == password1
                && insertedKeys[1] == password2
                && insertedKeys[2] == password3)
                {
                    StartCoroutine(ShowSuccess());
                }
                else
                {
                    StartCoroutine(ShowError());
                    return;
                }
            }
            UpdateScreen();
        }
        
    }

    IEnumerator ShowSuccess()
    {
        if (successAudio != null)
        {
            successAudio.Play();
        }

        yield return new WaitForSeconds(1f);

        passwordSuccess = true;
        Back();
        onSuccess?.Invoke();
    }

    IEnumerator ShowError()
    {
        if(errorAudio != null)
        {
            errorAudio.Play();
        }
        showingError = true;
        UpdateScreen(true);
        yield return new WaitForSeconds(1f);
        insertedKeys.Clear();
        UpdateScreen();
        showingError = false;
    }

    private void UpdateScreen(bool error = false)
    {
        Debug.Log("UpdateScreen");
        if (error)
        {
            Debug.Log("Showing Error");
            screenMaterial.SetTexture("_MainTex", screenError);
        }
        else
        {
            Debug.Log("Showing OK");
            switch (insertedKeys.Count)
            {
                case 1:
                    screenMaterial.SetTexture("_MainTex", screenInput1); 
                    break;
                case 2:
                    screenMaterial.SetTexture("_MainTex", screenInput2);
                    break;
                case 3:
                    screenMaterial.SetTexture("_MainTex", screenInput3);
                    break;
                default:
                    screenMaterial.SetTexture("_MainTex", screenEmtpy);
                    break;
            }
        }
        
    }

    public override bool IsActive()
    {
        return !passwordSuccess;
    }

    
}
