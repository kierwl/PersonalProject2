using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Metaverse
{
    public interface IInteractable
    {
        void Interact(); // 상호작용 기능
    }
    public class InteractionController : MonoBehaviour
    {
        public float interactionRange = 2f; // 상호작용 가능한 범위
        public GameObject interactionUI;//UI참조
        private IInteractable nearestInteractable = null;

        private void Start()
        {
            if (interactionUI != null) 
                interactionUI.SetActive(false);
        }

        void Update()
        {
            FindNearestInteractable();

            if (nearestInteractable != null)
            {
                interactionUI.SetActive(true); // UI 표시
                if (Input.GetKeyDown(KeyCode.F))
                {
                    nearestInteractable.Interact();
                }
            }
            else
            {
                interactionUI.SetActive(false); // UI 숨김
            }
        }
        void FindNearestInteractable()
        {
            nearestInteractable = null;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange);

            foreach (Collider2D collider in colliders)
            {
                IInteractable interactable = collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    nearestInteractable = interactable;
                    return;
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, interactionRange);
        }
    }
}
