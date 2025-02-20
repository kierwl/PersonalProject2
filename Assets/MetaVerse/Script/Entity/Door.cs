using Metaverse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen = false;
    private BoxCollider2D boxCollider;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider2D>(); // BoxCollider2D 가져오기
    }

    public void Interact()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
        boxCollider.enabled = !isOpen; // 문이 열리면 콜라이더 비활성화, 닫히면 활성화
        Debug.Log(isOpen ? "문이 열렸습니다!" : "문이 닫혔습니다!");
    }
}
