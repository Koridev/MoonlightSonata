using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    public Light light;
    public List<WallMatAndLight> wallMaterialsAndLights;

    private CameraMovement character;

    private bool active = false;
    private void Awake()
    {
        character = GameObject.FindWithTag("Player").GetComponent<CameraMovement>();
        UpdateInvisible();
    }

    void UpdateInvisible()
    {
        foreach (WallMatAndLight obj in wallMaterialsAndLights)
        {
            obj.material.SetFloat("_ShowInvisible", (active & !obj.light.enabled)? 1f : 0f);
        }
    }

    void SetViewDirection(Transform from)
    {
        foreach (WallMatAndLight obj in wallMaterialsAndLights)
        {
            obj.material.SetVector("_BlackLightDirection", new Vector4(from.forward.x, from.forward.y, from.forward.z, 0));//TODO nop, recalculate direction according to center point

            float intensity = Mathf.Clamp((4 - Vector3.Distance(from.position, obj.centerPoint.position)) / 4f, 0, 1);
            obj.material.SetFloat("_Intensity", intensity);
        }
    }

    public void OnGrab()
    {
        light.enabled = true;
        active = true;
        UpdateInvisible();
        SetViewDirection(character.transform);
    }

    public void OnRelease()
    {
        light.enabled = false;
        active = false;
        UpdateInvisible();
    }

    private void Update()
    {
        if (active)
        {
            Debug.Log($"Is active, setting viewdirection to {character.transform.forward}");
            UpdateInvisible();
            SetViewDirection(character.transform);
        }
    }
}

[Serializable]
public struct WallMatAndLight
{
    public Material material;
    public Light light;
    public Transform centerPoint;

    public WallMatAndLight(Material mat, Light light, Transform center)
    {
        this.material = mat;
        this.light = light;
        this.centerPoint = center;
    }
}
