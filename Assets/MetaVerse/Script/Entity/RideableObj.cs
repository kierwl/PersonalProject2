using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Metaverse;
using Cinemachine;

public class Rideable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform seatPosition;
    private GameObject player;
    private RideableController rideableController;
    private bool isRiding = false;
    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rideableController = GetComponent<RideableController>();
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();  // ������ ī�޶� ã��
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
        if (player == null || rideableController == null) return;

        isRiding = true;
        player.SetActive(false); // �÷��̾� ����
        player.transform.position = seatPosition.position; // �¼� ��ġ�� �̵�
        rideableController.SetRiding(true); // ž�¹� ���� Ȱ��ȭa

        // Cinemachine ī�޶� ����
        virtualCamera.Follow = transform;
        virtualCamera.LookAt = transform;
    }

    private void ExitRide()
    {
        if (player == null || rideableController == null) return;

        isRiding = false;
        player.SetActive(true); // �÷��̾� �ٽ� Ȱ��ȭ
        player.transform.position = transform.position + Vector3.right * 2; // ž�¹� ������ ������
        rideableController.SetRiding(false); // ž�¹� ���� ��Ȱ��ȭ

        // �ٽ� �÷��̾ ���󰡵��� ����
        virtualCamera.Follow = player.transform;
        virtualCamera.LookAt = player.transform;
    }
}

