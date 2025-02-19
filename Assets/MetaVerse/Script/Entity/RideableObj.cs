using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Metaverse;

public class RideableObj : MonoBehaviour,IInteractable
{
    [SerializeField] private Transform seatPosition; // ž�� ��ġ
    private GameObject player;
    private bool isRiding = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Interact()
    {
        if (isRiding)
        {
            ExitRide();
        }
        else
        {
            EnterRide();
        }
    }

    private void EnterRide()
    {
        if (player == null) return;

        isRiding = true;
        player.SetActive(false); // �÷��̾� ����
        player.transform.position = seatPosition.position; // �÷��̾� ��ġ �̵�
        Debug.Log(" ž�� �Ϸ�! ���� ž�¹��� ������ �� �ֽ��ϴ�.");
    }

    private void ExitRide()
    {
        if (player == null) return;

        isRiding = false;
        player.SetActive(true); // �÷��̾� �ٽ� Ȱ��ȭ
        player.transform.position = transform.position + Vector3.right * 2; // ž�¹� ������ ������
        Debug.Log(" ž�� ����! �÷��̾� �������� ����.");
    }
}
