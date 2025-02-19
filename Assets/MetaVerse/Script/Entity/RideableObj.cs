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
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();  // 씬에서 카메라 찾기
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
        player.SetActive(false); // 플레이어 숨김
        player.transform.position = seatPosition.position; // 좌석 위치로 이동
        rideableController.SetRiding(true); // 탑승물 조작 활성화a

        // Cinemachine 카메라 변경
        virtualCamera.Follow = transform;
        virtualCamera.LookAt = transform;
    }

    private void ExitRide()
    {
        if (player == null || rideableController == null) return;

        isRiding = false;
        player.SetActive(true); // 플레이어 다시 활성화
        player.transform.position = transform.position + Vector3.right * 2; // 탑승물 옆으로 내려줌
        rideableController.SetRiding(false); // 탑승물 조작 비활성화

        // 다시 플레이어를 따라가도록 변경
        virtualCamera.Follow = player.transform;
        virtualCamera.LookAt = player.transform;
    }
}

