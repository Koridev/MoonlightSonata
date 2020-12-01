using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class InvisibleInkController : MonoBehaviour
{
    public Transform lightDirection;
    public bool state;

    private Material invisibleInk;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(var material in GetComponent<MeshRenderer>().materials)
        {
            if(material.shader.name == "Shader Graphs/BlackLightVisible")
            {
                invisibleInk = material;
            }
        }

        if(invisibleInk == null)
        {
            Debug.LogError("No material with name Shader Graphs/BlackLightVisible was found, the invisible ink won't work");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(invisibleInk != null)
        {
            invisibleInk.SetFloat("_ShowInvisible", state ? 1f : 0f);
            invisibleInk.SetVector("_BlackLightDirection", lightDirection.forward);
        }
       
    }
}
