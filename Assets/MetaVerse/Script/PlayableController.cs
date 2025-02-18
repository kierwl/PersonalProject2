using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class PlayableController : BaseEntity
    {
        public string playerName = "Player";

        void Start()
        {
            Debug.Log($"{playerName} ĳ���Ͱ� �����Ǿ����ϴ�!");
        }

        protected override void Update()
        {
            base.Update(); // �θ� Ŭ������ Update() ����

            // �߰� ���: ��� (Dash) ����
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Dash();
            }
        }

        void Dash()
        {
            Vector3 dashPosition = transform.position + (Vector3)moveInput * 2f;
            transform.position = dashPosition;
            Debug.Log($"{playerName}�� ����߽��ϴ�!");
        }
    }
}
