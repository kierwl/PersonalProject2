using UnityEngine;
using Metaverse;

public class RideableController : BaseEntity
{
    private bool isRiding = false;

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isRiding)// 탑승여부 관계없이 f를 눌러 내릴 수 있음
        {
            ExitRide();
            return;
        }

        if (isRiding)
        {
            base.Update(); // 탑승 중일 때만 이동 가능
        }
    }

    public void SetRiding(bool riding)
    {
        isRiding = riding;
    }
    private void ExitRide()
    {
        // Rideable 스크립트에서 탈출 기능을 실행하도록 설정
        GetComponent<Rideable>().Interact();
    }
}
