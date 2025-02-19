using UnityEngine;
using Metaverse;

public class RideableController : BaseEntity
{
    private bool isRiding = false;

    protected override void Update()
    {
        if (isRiding)
        {
            base.Update(); // 탑승 중일 때만 이동 가능
        }
    }

    public void SetRiding(bool riding)
    {
        isRiding = riding;
    }
}
