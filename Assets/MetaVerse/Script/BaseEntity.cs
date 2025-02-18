using System.Collections;
using System.Collections.Generic;
using Topdown;
using UnityEngine;
namespace Metaverse
{
    public class BaseEntity : MonoBehaviour
    {
        public float moveSpeed = 5f;     // �̵� �ӵ�
        public float jumpHeight = 2f;    // ���� ����
        public float jumpDuration = 0.3f; // ���� ���� �ð�
        public float gravity = 9.8f;     // �߷� ���ӵ�

        protected Vector2 moveInput;
        private bool isJumping = false;
        private bool isGrounded = true;
        private float jumpStartTime;
        private float velocityY = 0f; // ���� y�� �ӵ� (�߷� ����)

        protected virtual void Update()
        {
            Move();
            ApplyGravity();
            Jump();
            Interact();
        }

        protected void Move()
        {
            float moveX = Input.GetAxis("Horizontal"); // �¿� �̵� (X��)
            float moveZ = Input.GetAxis("Vertical");   // �յ� �̵� (Z��)
            float moveY = 0f;

            if (Input.GetKey(KeyCode.E)) moveY = 1f;  // Y�� ��� (E Ű)
            if (Input.GetKey(KeyCode.Q)) moveY = -1f; // Y�� �ϰ� (Q Ű)

            moveInput = new Vector2(moveX, moveZ).normalized;

            Vector3 moveVector = new Vector3(moveInput.x, moveY, moveInput.y) * moveSpeed * Time.deltaTime;
            moveVector.y += velocityY * Time.deltaTime; // �߷� ����

            transform.position += moveVector;
        }

        protected void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isJumping = true;
                isGrounded = false;
                jumpStartTime = Time.time;
                velocityY = Mathf.Sqrt(2 * gravity * jumpHeight); // ���� �ӵ� ����
            }
        }

        protected void ApplyGravity()
        {
            if (!isGrounded)
            {
                velocityY -= gravity * Time.deltaTime; // �߷� ����
            }

            // �ٴڿ� ��Ҵ��� Ȯ�� (���� ���̰� 0 �����̸�, �Ʒ��� �������� ���̸� ����)
            if (transform.position.y <= 0f && velocityY <= 0f)
            {
                isGrounded = true;
                velocityY = 0f;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z); // �ٴ� ��ġ ����
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
                Debug.Log("��ȣ�ۿ� ����!");
            }
        }
    }
}


