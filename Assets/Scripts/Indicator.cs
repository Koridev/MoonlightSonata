using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public bool on;
    public Color color = Color.white;

    private Light[] lights;
    private MeshRenderer meshRenderer;

    void Awake()
    {
        lights = GetComponentsInChildren<Light>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.materials[1].color = on ? new Color(color.r, color.g, color.b, 0.5f) : new Color(1f, 1f, 1f, 0.25f);
        foreach (Light light in lights)
        {
            light.color = color;
            light.enabled = on;
        }
    }
}
