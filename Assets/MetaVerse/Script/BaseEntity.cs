using System.Collections;
using System.Collections.Generic;
using Topdown;
using UnityEngine;
namespace Metaverse
{
    public class BaseEntity : MonoBehaviour
    {
        public float moveSpeed = 5f;     // �̵� �ӵ�
        public float jumpHeight = 0.5f;  // ���� ���� (0.5)
        public float jumpDuration = 0.3f; // ���� ���� �ð�
        public float verticalMoveSpeed = 3f; // Y�� �̵� �ӵ� (E/Q)

        private Vector3 originalPosition; // ���� �� ��ġ ����
        private bool isJumping = false;   // ���� ���� üũ

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
            float moveX = Input.GetAxis("Horizontal"); // �¿� �̵� (X��)
            float moveZ = Input.GetAxis("Vertical");   // �յ� �̵� (Z��)
            float moveY = 0f;

            if (Input.GetKey(KeyCode.W)) moveY = 1f;  // Y�� ��� (W Ű)
            if (Input.GetKey(KeyCode.S)) moveY = -1f; // Y�� �ϰ� (S Ű)

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
            while (elapsedTime < jumpDuration / 2) // ���
            {
                transform.position = Vector3.Lerp(originalPosition, jumpTarget, (elapsedTime / (jumpDuration / 2)));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = jumpTarget; // �ְ��� ����

            elapsedTime = 0f;
            while (elapsedTime < jumpDuration / 2) // �ϰ�
            {
                transform.position = Vector3.Lerp(jumpTarget, originalPosition, (elapsedTime / (jumpDuration / 2)));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = originalPosition; // ���� ��ġ ����
            isJumping = false;
        }
    }
}


