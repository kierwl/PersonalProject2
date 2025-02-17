using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown
{
    public class PlayerController : BaseController
    {
        private Camera camera;

        protected override void Start()
        {
            base.Start();
            camera = Camera.main;
        }

        protected override void HandleAction()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            movementDirection = new Vector2(horizontal, vertical).normalized;

            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition); // 해상도 좌표를 월드 좌표로 변환
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
    }
}
