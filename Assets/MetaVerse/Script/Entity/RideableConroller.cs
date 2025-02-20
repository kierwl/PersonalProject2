using UnityEngine;
using Metaverse;

public class RideableController : BaseEntity
{
    private bool isRiding = false;

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isRiding)// ž�¿��� ������� f�� ���� ���� �� ����
        {
            ExitRide();
            return;
        }

        if (isRiding)
        {
            base.Update(); // ž�� ���� ���� �̵� ����
        }
    }

    public void SetRiding(bool riding)
    {
        isRiding = riding;
    }
    private void ExitRide()
    {
        // Rideable ��ũ��Ʈ���� Ż�� ����� �����ϵ��� ����
        GetComponent<Rideable>().Interact();
    }
}
