using UnityEngine;

public class XORBehaviour : CursorControllingBehaviour
{
    BinaryButtonsManager manager;


    protected override void Awake()
    {
        base.Awake();
        manager = GetComponent<BinaryButtonsManager>();
        if(manager == null)
        {
            Debug.LogError("Component BinaryButtonsManager could not be found");
        }
    }
    public override LayerMask GetClickableLayer()
    {
        return LayerMask.NameToLayer("XOR");
    }

    public override bool IsActive()
    {
        if(manager != null)
        {
            return !manager.IsOver();
        }
        else
        {
            return false;
        }
        
    }
}
