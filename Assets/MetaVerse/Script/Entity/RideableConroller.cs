using UnityEngine;
using Metaverse;

public class RideableController : BaseEntity
{
    private bool isRiding = false;

    protected override void Update()
    {
        if (isRiding)
        {
            base.Update(); // ž�� ���� ���� �̵� ����
        }
    }

    public void SetRiding(bool riding)
    {
        isRiding = riding;
    }
}
