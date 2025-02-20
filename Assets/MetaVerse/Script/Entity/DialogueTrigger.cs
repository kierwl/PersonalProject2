using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Metaverse;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public DialogueManager.Dialogue dialogue;
    public DialogueManager dialogueManager;

    public float triggerRadius = 3f; // 감지 범위
    private GameObject player;
    private bool dialogueStarted = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // 플레이어 태그로 찾기
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
            dialogueStarted = true; // 대화 중복 실행 방지
        }
        else
        {
            Debug.LogWarning("DialogueManager 또는 Dialogue가 설정되지 않았습니다!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // 기즈모 색상
        Gizmos.DrawWireSphere(transform.position, triggerRadius); // 감지 범위 표시
    }

    public void Interact()
    {
        // 자동으로 대화 시작
        dialogueManager.StartDialogue(dialogue);
    }
}
