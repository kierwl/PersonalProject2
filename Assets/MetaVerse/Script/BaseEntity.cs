using System.Collections;
using System.Collections.Generic;
using Topdown;
using UnityEngine;
namespace Metaverse
{
    public class BaseEntity : MonoBehaviour
    {
        public float moveSpeed = 5f;     // 이동 속도
        public float jumpHeight = 0.5f;  // 점프 높이 (0.5)
        public float jumpDuration = 0.3f; // 점프 지속 시간
        public float verticalMoveSpeed = 3f; // Y축 이동 속도 (E/Q)

        private Vector3 originalPosition; // 점프 전 위치 저장
        private bool isJumping = false;   // 점프 상태 체크

        protected virtual void Update()
        {
            Move();
            if (!isJumping)
            {
                Jump();
            }
        }

        protected void Move()
        {
            float moveX = Input.GetAxis("Horizontal"); // 좌우 이동 (X축)
            float moveZ = Input.GetAxis("Vertical");   // 앞뒤 이동 (Z축)
            float moveY = 0f;

            if (Input.GetKey(KeyCode.W)) moveY = 1f;  // Y축 상승 (W 키)
            if (Input.GetKey(KeyCode.S)) moveY = -1f; // Y축 하강 (S 키)

            Vector3 moveVector = new Vector3(moveX, moveY * verticalMoveSpeed, moveZ).normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }

        protected void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                StartCoroutine(JumpRoutine());
            }
        }

        private IEnumerator JumpRoutine()
        {
            isJumping = true;
            originalPosition = transform.position;
            Vector3 jumpTarget = originalPosition + new Vector3(0, jumpHeight, 0);

            float elapsedTime = 0f;
            while (elapsedTime < jumpDuration / 2) // 상승
            {
                transform.position = Vector3.Lerp(originalPosition, jumpTarget, (elapsedTime / (jumpDuration / 2)));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = jumpTarget; // 최고점 유지

            elapsedTime = 0f;
            while (elapsedTime < jumpDuration / 2) // 하강
            {
                transform.position = Vector3.Lerp(jumpTarget, originalPosition, (elapsedTime / (jumpDuration / 2)));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = originalPosition; // 원래 위치 복귀
            isJumping = false;
        }
    }
}


