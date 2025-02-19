using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Metaverse;

public class RideableObj : MonoBehaviour,IInteractable
{
    [SerializeField] private Transform seatPosition; // 탑승 위치
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
        player.SetActive(false); // 플레이어 숨김
        player.transform.position = seatPosition.position; // 플레이어 위치 이동
        Debug.Log(" 탑승 완료! 이제 탑승물을 조작할 수 있습니다.");
    }

    private void ExitRide()
    {
        if (player == null) return;

        isRiding = false;
        player.SetActive(true); // 플레이어 다시 활성화
        player.transform.position = transform.position + Vector3.right * 2; // 탑승물 옆으로 내려줌
        Debug.Log(" 탑승 해제! 플레이어 조작으로 복귀.");
    }
}
