using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlidingLaser : WallSlidingObject
{

    public override bool Process(Transform character, Vector3 m)
    {
        if (grabbing)
        {
            character.Rotate(m.y, m.x, m.z);

            var tuple = GetLookAtPosition(character.rotation);
            Vector3? onRailPosition = tuple.Item1;
            Line rail = tuple.Item2;
            if (onRailPosition != null)
            {
                character.LookAt(onRailPosition.Value, character.up);

                positionOnSphere = character.rotation;

                Vector3 movement = onRailPosition.Value - transform.position;
                //place the object on the wall at the current rotation
                transform.position = onRailPosition.Value;

                rotationOffset.SetFromToRotation(transform.forward * 2, (transform.forward * 2) - movement);

                transform.rotation = rotationOffset * transform.rotation;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

}
