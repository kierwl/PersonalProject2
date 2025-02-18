using Metaverse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Interact()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
        Debug.Log(isOpen ? "¹®ÀÌ ¿­·È½À´Ï´Ù!" : "¹®ÀÌ ´ÝÇû½À´Ï´Ù!");
    }
}
