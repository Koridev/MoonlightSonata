using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public enum RadioMode
{
    F,G,H,J,K,L
}

[System.Serializable]
public struct RadioSource
{
    public AudioSource source;
    [Range(0f, 1f)]
    public float maxVolume;

    [Range(0.05f, 0.95f)]
    public float frequency;
    public RadioMode mode;
}

public class RadioBehaviour : CursorControllingBehaviour
{
    private bool power;
    private RadioMode? mode;
    private float frequency = 0.05f;

    public RadioModeButtonController Fkey;
    public RadioModeButtonController Gkey;
    public RadioModeButtonController Hkey;
    public RadioModeButtonController Jkey;
    public RadioModeButtonController Kkey;
    public RadioModeButtonController Lkey;

    public RadioKnobController knob;

    public RadioPowerButtonController powerButton;

    public AudioSource staticNull;

    public List<RadioSource> sounds;

    public AudioSource noiseF;
    public AudioSource noiseG;
    public AudioSource noiseH;
    public AudioSource noiseJ;
    public AudioSource noiseK;
    public AudioSource noiseL;

    //public AudioSource sound;
    //public AudioSource noise;

    public AudioSource knobTic;
    public AudioSource switchAudio;

    float spinValue = 0f;

    //[Range(0f, 1f)]
    //public float soundFrequency = 0.5f;
    //public RadioMode soundMode = RadioMode.H;

    protected override void Awake()
    {
        base.Awake();
        UpdateRadio();
    }

    public override LayerMask GetClickableLayer()
    {
        return LayerMask.NameToLayer("Radio");
    }

    protected override void Update()
    {
        base.Update();

        if (!knob.IsClicked())
        {
            spinValue = 0;
        }

        float newFrequency = Mathf.Clamp(frequency + (spinValue * 0.2f * Time.deltaTime), 0.05f, 0.95f);
        if (spinValue != 0 && frequency != newFrequency)
        {
            if (!knobTic.isPlaying)
            {
                knobTic.Play();
            }

            SetFrequency(newFrequency);
        }
        else
        {
            knobTic.Stop();
        }

    }

    public void SetMode(RadioMode mode)
    {
        if (this.mode == mode)
        {
            this.mode = null;
        }
        else
        {
            this.mode = mode;
        }

        UpdateRadio();
    }

    public void SwitchPower()
    {
        this.power = !power;
        switchAudio.Play();
        UpdateRadio();
    }

    public void SetFrequency(float frequency)
    {
        this.frequency = Mathf.Clamp(frequency, 0.05f, 0.95f);
        UpdateRadio();
    }

    static readonly float frequencyError = 0.05f;

    private void UpdateRadio()
    {
        Fkey.SetPressed(mode == RadioMode.F);
        Gkey.SetPressed(mode == RadioMode.G);
        Hkey.SetPressed(mode == RadioMode.H);
        Jkey.SetPressed(mode == RadioMode.J);
        Kkey.SetPressed(mode == RadioMode.K);
        Lkey.SetPressed(mode == RadioMode.L);

        knob.SetFrequency(frequency);

        powerButton.SetPower(power);

        noiseF.mute = !power || mode != RadioMode.F;
        noiseG.mute = !power || mode != RadioMode.G;
        noiseH.mute = !power || mode != RadioMode.H;
        noiseJ.mute = !power || mode != RadioMode.J;
        noiseK.mute = !power || mode != RadioMode.K;
        noiseL.mute = !power || mode != RadioMode.L;

        foreach (var sound in sounds)
        {
            sound.source.mute = !power || mode != sound.mode;
            if(mode == null)
            {
                sound.source.volume = 0;
            }
        }

        if(mode == null)
        {
            noiseF.volume = 0;
            noiseG.volume = 0;
            noiseH.volume = 0;
            noiseJ.volume = 0;
            noiseK.volume = 0;
            noiseL.volume = 0;

            staticNull.mute = !power;
        }
        else
        {
            staticNull.mute = true;

            float noiseMinus = 0;
            foreach (var sound in sounds.Where(s => s.mode == mode))
            {
                if (frequency >= sound.frequency - frequencyError && frequency <= sound.frequency + frequencyError)
                {
                    float value = 1 - Mathf.InverseLerp(0, frequencyError, Mathf.Abs(sound.frequency - frequency));
                    sound.source.volume = value;

                    noiseMinus += value;
                }
                else
                {
                    sound.source.volume = 0;
                }
            }

            GetNoise(mode.Value).volume = Mathf.Clamp(1 - noiseMinus, 0, 1);

            


            //if (mode == soundMode && (frequency >= soundFrequency - frequencyError && frequency <= soundFrequency + frequencyError))
            //{

            //    float value = 1 - Mathf.InverseLerp(0, frequencyError, Mathf.Abs(soundFrequency - frequency));
            //    noise.volume = 1- value;
            //    sound.volume = value;
            //}
            //else
            //{
            //    noise.volume = 1;
            //    sound.volume = 0;
            //}
        }

        
    }

    private AudioSource GetNoise(RadioMode mode)
    {
        switch (mode)
        {
            case RadioMode.F:
                return noiseF;
            case RadioMode.G:
                return noiseG;
            case RadioMode.H:
                return noiseH;
            case RadioMode.J:
                return noiseJ;
            case RadioMode.K:
                return noiseK;
            case RadioMode.L:
                return noiseL;
            default:
                return null;
        }
    }

    public override void OnLookX(InputAction.CallbackContext context)
    {
        if (knob.IsClicked())
        {
            spinValue = context.ReadValue<float>();
            Debug.Log(spinValue);
        }
        else
        {
            base.OnLookX(context);
        }
    }

    public override void OnLookY(InputAction.CallbackContext context)
    {
        if (!knob.IsClicked())
        {
            base.OnLookY(context);
        }
    }

}
