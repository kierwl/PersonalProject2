using Metaverse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public GameObject customizationUI; // UI ÆÐ³Î
    private bool isUIOpen = false;

    public void Interact()
    {
        ToggleUI();
    }

    public void ToggleUI()
    {
        isUIOpen = !isUIOpen;
        customizationUI.SetActive(isUIOpen);
    }
}
