using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Metaverse;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public DialogueManager.Dialogue dialogue;
    public DialogueManager dialogueManager;

    public float triggerRadius = 3f; // ���� ����
    private GameObject player;
    private bool dialogueStarted = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // �÷��̾� �±׷� ã��
    }


    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= triggerRadius && !dialogueStarted)
        {
            TriggerDialogue();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    private void TriggerDialogue()
    {
        if (dialogueManager != null && dialogue != null)
        {
            dialogueManager.StartDialogue(dialogue);
            dialogueStarted = true; // ��ȭ �ߺ� ���� ����
        }
        else
        {
            Debug.LogWarning("DialogueManager �Ǵ� Dialogue�� �������� �ʾҽ��ϴ�!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // ����� ����
        Gizmos.DrawWireSphere(transform.position, triggerRadius); // ���� ���� ǥ��
    }

    public void Interact()
    {
        // �ڵ����� ��ȭ ����
        dialogueManager.StartDialogue(dialogue);
    }
}
