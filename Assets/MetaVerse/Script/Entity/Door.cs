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
        boxCollider = GetComponent<BoxCollider2D>(); // BoxCollider2D ��������
    }

    public void Interact()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
        boxCollider.enabled = !isOpen; // ���� ������ �ݶ��̴� ��Ȱ��ȭ, ������ Ȱ��ȭ
        Debug.Log(isOpen ? "���� ���Ƚ��ϴ�!" : "���� �������ϴ�!");
    }
}
