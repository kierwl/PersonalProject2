using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Metaverse;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public DialogueManager.Dialogue dialogue;
    public DialogueManager dialogueManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.DisplayNextSentence();
        }
    }


    public void Interact()
    {
        // �ڵ����� ��ȭ ����
        dialogueManager.StartDialogue(dialogue);
    }
}
