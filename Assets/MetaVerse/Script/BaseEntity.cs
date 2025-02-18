using System.Collections;
using System.Collections.Generic;
using Topdown;
using UnityEngine;
namespace Metaverse
{
    public class BaseEntity : MonoBehaviour
    {
        public float moveSpeed = 5f;     // 이동 속도
        public float jumpHeight = 2f;    // 점프 높이
        public float jumpDuration = 0.3f; // 점프 지속 시간
        public float gravity = 9.8f;     // 중력 가속도

        protected Vector2 moveInput;
        private bool isJumping = false;
        private bool isGrounded = true;
        private float jumpStartTime;
        private float velocityY = 0f; // 현재 y축 속도 (중력 적용)

        protected virtual void Update()
        {
            Move();
            ApplyGravity();
            Jump();
            Interact();
        }

        protected void Move()
        {
            float moveX = Input.GetAxis("Horizontal"); // 좌우 이동 (X축)
            float moveZ = Input.GetAxis("Vertical");   // 앞뒤 이동 (Z축)
            float moveY = 0f;

            if (Input.GetKey(KeyCode.E)) moveY = 1f;  // Y축 상승 (E 키)
            if (Input.GetKey(KeyCode.Q)) moveY = -1f; // Y축 하강 (Q 키)

            moveInput = new Vector2(moveX, moveZ).normalized;

            Vector3 moveVector = new Vector3(moveInput.x, moveY, moveInput.y) * moveSpeed * Time.deltaTime;
            moveVector.y += velocityY * Time.deltaTime; // 중력 적용

            transform.position += moveVector;
        }

        protected void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isJumping = true;
                isGrounded = false;
                jumpStartTime = Time.time;
                velocityY = Mathf.Sqrt(2 * gravity * jumpHeight); // 점프 속도 설정
            }
        }

        protected void ApplyGravity()
        {
            if (!isGrounded)
            {
                velocityY -= gravity * Time.deltaTime; // 중력 적용
            }

            // 바닥에 닿았는지 확인 (현재 높이가 0 이하이며, 아래로 떨어지는 중이면 착지)
            if (transform.position.y <= 0f && velocityY <= 0f)
            {
                isGrounded = true;
                velocityY = 0f;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z); // 바닥 위치 유지
            }
            else
            {
                isGrounded = false;
            }
        }

        protected void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("상호작용 실행!");
            }
        }
    }
}


