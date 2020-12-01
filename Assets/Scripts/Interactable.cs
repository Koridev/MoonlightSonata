using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public static Color INTERACTION_COLOR = new Color(0.9568627f, 0.6666667f, 0.3176471f);
    public GrabbableIdentifier grabbingFilter;
    protected CameraMovement cameraMovement;
    protected Collider collider;

    public MeshRenderer meshRenderer;
    public List<MeshRenderer> extraMeshRenderers;

    protected virtual void Awake()
    {
        cameraMovement = GameObject.FindWithTag("Player").GetComponent<CameraMovement>();
        collider = GetComponent<Collider>();
       
        if(meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        if (meshRenderer != null)
        {
            HighlightMesh(meshRenderer, false);
        }

        foreach(var mesh in extraMeshRenderers)
        {
            HighlightMesh(mesh, false);
        }


    }

    private void HighlightMesh(MeshRenderer mesh, bool highlight)
    {
        //Hide higlight
        foreach (Material mat in mesh.materials)
        {
            mat.SetFloat("_Highlight", highlight? 1f: 0f);
        }
    }

    protected virtual void Update()
    {
        if (collider == null)
        {
            Debug.LogError(gameObject.name);
        }
        else
        {
            collider.enabled = IsActive();
        }
    }

    protected bool active = true;
    public virtual bool Process(Transform character, Vector3 movement)
    {
        return false;
    }

    public abstract void OnDown(Vector3 hitPoint);

    public abstract void OnUp();

    public abstract string GetHint();

    public virtual void Hover()
    {
        if (meshRenderer != null && CanHighlight())
        {
            //Show highlight
            HighlightMesh(meshRenderer, true);
            foreach(var mesh in extraMeshRenderers)
            {
                HighlightMesh(mesh, true);
            }
        }
    }

    public virtual void OnLost()
    {
        if (meshRenderer != null)
        {
            //Hide higlight
            HighlightMesh(meshRenderer, false);
            foreach (var mesh in extraMeshRenderers)
            {
                HighlightMesh(mesh, false);
            }
        }
    }

    public virtual Color AimColor()
    {
        return INTERACTION_COLOR;
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }

    public virtual bool IsActive()
    {
        if(grabbingFilter != GrabbableIdentifier.None)
        {
            return active && cameraMovement.IsGrabbing(grabbingFilter);
        }
        else
        {
            return active;
        }
        
    }

    protected virtual bool CanHighlight()
    {
        return true;
    }



    

}
