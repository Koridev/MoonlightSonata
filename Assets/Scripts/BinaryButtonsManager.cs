using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BinaryButtonsManager : MonoBehaviour
{

    public int lightCount = 9;
    public int buttonCount = 3;
    public UnityEvent onSuccess;

    int solution = 0;
    List<int> buttonEffectList;
    List<bool> buttonStates;
    bool gameOver = false;

    bool overrideLight = false;
    bool overrideLightState = false;

    public AudioSource successBipAudio;

    void Awake()
    { 
        buttonEffectList = new List<int>();
        buttonStates = new List<bool>();
        for(int i=0; i < buttonCount; i++)
        {
            buttonStates.Add(false);
        }
        ButtonInitializer.Predefined(lightCount, buttonCount, buttonEffectList, out solution);
    }

    public void PressButton(int index)
    {
        if (!gameOver)
        {
            if(index < buttonStates.Count)
            {
                buttonStates[index] = !buttonStates[index];
                CheckGameOver();
            }
        }
    }

    private void CheckGameOver()
    {
        bool success = true;
        for(int i=0; i<lightCount; i++)
        {
            success = success && GetLightState(i);
        }
        gameOver = success;
        if (gameOver)
        {
            StartCoroutine(OnSuccess());
        }
    }

    IEnumerator OnSuccess()
    {
        overrideLight = true;
        overrideLightState = true;
        yield return new WaitForSeconds(0.4f);
        overrideLightState = false;
        yield return new WaitForSeconds(0.4f);
        successBipAudio.Play();
        overrideLightState = true;
        yield return new WaitForSeconds(0.4f);
        overrideLightState = false;
        yield return new WaitForSeconds(0.4f);
        successBipAudio.Play();
        overrideLightState = true;
        yield return new WaitForSeconds(0.4f);

        onSuccess?.Invoke();
    }

    public bool GetLightState(int index)
    {
        if (overrideLight)
        {
            return overrideLightState;
        }

        bool state = (solution & (1 << index)) == 0;
        for(int i=0; i<buttonCount; i++)
        {
            if (buttonStates[i])
            {
                state = state ^ (buttonEffectList[i] & (1 << index)) != 0;
            }
        }
        return state;
    }

    public List<bool> GetButtonEffect(int index)
    {
        int value = buttonEffectList[index];
        List<bool> effects = new List<bool>();

        for(int i=0; i<lightCount; i++)
        {
            effects.Add((value & (1 << i)) != 0);
        }

        return effects;
    }

    public bool IsOver()
    {
        return gameOver;
    }
}

public static class ButtonInitializer
{
    public static void Random(int lightCount, int buttonCount, List<int> buttonEffectList, out int solution)
    {
        solution = 0;
        int maxValue = Mathf.RoundToInt(Mathf.Pow(2, lightCount) - 1);

        for (int i = 0; i < buttonCount; i++)
        {
            int value = UnityEngine.Random.Range(0, maxValue);
            buttonEffectList.Add(value);

            bool addToResult = UnityEngine.Random.value >= 0.5f;
            if (addToResult)
            {
                solution ^= value;
            }
        }

        solution = Mathf.Min(solution, maxValue);
    }

    public static void Predefined(int lightCount, int buttonCount, List<int> buttonEffectList, out int solution)
    {
        solution = 408;

        buttonEffectList.Add(0b100100010); //0b010001001
        buttonEffectList.Add(0b000110110); //0b011011000
        buttonEffectList.Add(0b010110110); //0b011011010
        buttonEffectList.Add(0b011111001); //0b100111110
        buttonEffectList.Add(0b000001100); //0b001100000
    }
}
