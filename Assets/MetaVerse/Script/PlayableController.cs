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
            Debug.Log($"{playerName} 캐릭터가 생성되었습니다!");
        }

        protected override void Update()
        {
            base.Update(); // 부모 클래스의 Update() 실행

            // 추가 기능: 대시 (Dash) 구현
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Dash();
            }
        }

        void Dash()
        {
            Vector3 dashPosition = transform.position + (Vector3)moveInput * 2f;
            transform.position = dashPosition;
            Debug.Log($"{playerName}가 대시했습니다!");
        }
    }
}
