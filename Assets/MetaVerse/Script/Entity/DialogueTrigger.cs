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
        // 자동으로 대화 시작
        dialogueManager.StartDialogue(dialogue);
    }
}
