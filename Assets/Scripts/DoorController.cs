using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorController : MonoBehaviour
{
    public bool open;
    public TunnelDoor tunnel;
    Animator animator;

    public AudioSource openCloseSound;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Open", open);
        tunnel.SetActive(open);
    }

    public void SetOpen(bool open)
    {
        if(open != this.open && openCloseSound != null)
        {
            openCloseSound.Play();
        }
        this.open = open;

    }
}
