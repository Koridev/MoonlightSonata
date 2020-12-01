using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailAttached : Interactable
{
    public Rail attachedTo;
    public float position;

    private bool grabbed = false;

    public void Move(Vector2 movement)
    {
        //TODO 
    }

    private bool AddToPosition(float offset)
    {
        bool result = false;
        if(position + offset < 0)
        {
            position = 0;
        }
        else if(position + offset > 1)
        {
            position = 1;
        }
        else
        {
            position += offset;
            result = true;
        }
        UpdatePosition();
        return result;
    }

    private void UpdatePosition()
    {
        attachedTo.MoveAt(transform, position);
    }

    protected override void Update()
    {
        base.Update();
        UpdatePosition();
    }

    public override bool Process(Transform character, Vector3 movement)
    {
        if (grabbed)
        {
            Vector3 project = Vector3.ProjectOnPlane(movement, transform.up);
            Debug.Log($"Project {project}");

            Vector3 beforeForward = character.forward;

            character.Rotate(project.y, project.x, project.z, Space.World);

            float signedAngle = Vector3.SignedAngle(beforeForward, character.forward, character.up);
            if(!AddToPosition(signedAngle / attachedTo.angle))
            {
                character.Rotate(-project.y, -project.x, -project.z, Space.World);
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public override void OnDown(Vector3 hitPoint)
    {
        grabbed = true;
    }

    public override void OnUp()
    {
        grabbed = false;
    }

    public override string GetHint()
    {
        return "Grab";
    }
}
