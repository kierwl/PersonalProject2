using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Topdown
{
    public class PlayerController : BaseController
    {
        private Camera playerCamera;
        private GameManager gameManager;

        public void Init(GameManager gameManager)
        {
            this.gameManager = gameManager;
            playerCamera = Camera.main;
        }

        protected override void HandleAction()
        {

        }

        public override void Death()
        {
            base.Death();
            gameManager.GameOver();
        }

        void OnMove(InputValue inputValue)
        {
            movementDirection = inputValue.Get<Vector2>();
            movementDirection = movementDirection.normalized;
        }

        void OnLook(InputValue inputValue)
        {
            Vector2 mousePosition = inputValue.Get<Vector2>();
            Vector2 worldPos = playerCamera.ScreenToWorldPoint(mousePosition);
            lookDirection = (worldPos - (Vector2)transform.position);

            if (lookDirection.magnitude < .9f)
            {
                lookDirection = Vector2.zero;
            }
            else
            {
                lookDirection = lookDirection.normalized;
            }
        }

        void OnFire(InputValue inputValue)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            isAttacking = inputValue.isPressed;
        }
    }
}
