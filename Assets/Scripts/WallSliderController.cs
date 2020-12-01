using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSliderController : MonoBehaviour
{
    public WallSlidingObject target;
    public float speed = 10;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(!EqualsAround(transform.localEulerAngles.y, 0, 2.5f) && !EqualsAround(transform.localEulerAngles.y, 180, 2.5f))
        {
            vertical = 0;
        }

        if (!EqualsAround(transform.localEulerAngles.z, 90, 2.5f) && !EqualsAround(transform.localEulerAngles.z, 270, 2.5f))
        {
            horizontal = 0;
        }

        float rotY = transform.localRotation.eulerAngles.y + horizontal * Time.deltaTime * speed;
        float rotZ = transform.localRotation.eulerAngles.z + vertical * Time.deltaTime * speed;
        
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, rotY, rotZ);

        if(target != null)
        {
            target.positionOnSphere = transform.localRotation * Quaternion.Euler(-90,0,0);
        } 
    }

    private bool EqualsAround(float a, float b, float delta)
    {
        return a > b - delta && a < b + delta;
    }


}
