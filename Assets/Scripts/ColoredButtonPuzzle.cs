using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ColoredButtonType
{
    BLUE, YELLOW, RED, GREEN
}
public class ColoredButtonPuzzle : CursorControllingBehaviour
{
    private static readonly int LENGTH = 4;
    ColoredButtonType[] inputs = new ColoredButtonType[LENGTH];

    public ColoredButtonType input1;
    public ColoredButtonType input2;
    public ColoredButtonType input3;
    public ColoredButtonType input4;

    public UnityEvent onSuccess;

    public void AddInput(ColoredButtonType input)
    {
        if(inputs.Length == LENGTH)
        {
            for(int i=1; i< LENGTH; i++)
            {
                inputs[i - 1] = inputs[i];
            }
            inputs[LENGTH-1] = input;
        }
        else
        {
            inputs[inputs.Length] = input;
        }

        CheckInput();
    }

    private void CheckInput()
    {
        if(inputs.Length == LENGTH 
        && inputs[0] == input1
        && inputs[1] == input2
        && inputs[2] == input3
        && inputs[3] == input4)
        {
            Back();
            onSuccess.Invoke();
        }
    }

    public override LayerMask GetClickableLayer()
    {
        return LayerMask.NameToLayer("XOR");
    }
}
