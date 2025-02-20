using Metaverse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public GameObject customizationUI; // UI ÆÐ³Î
    private bool isUIOpen = false;
    private Animator animator;
    private bool isOpen = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }

    public void Interact()
    {
        ToggleUI();
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }

    public void ToggleUI()
    {
        isUIOpen = !isUIOpen;
        customizationUI.SetActive(isUIOpen);
    }
}
