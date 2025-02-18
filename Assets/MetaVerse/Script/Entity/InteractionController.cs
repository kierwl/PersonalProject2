using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Metaverse
{
    public interface IInteractable
    {
        void Interact(); // ��ȣ�ۿ� ���
    }
    public class InteractionController : MonoBehaviour
    {
        public float interactionRange = 2f; // ��ȣ�ۿ� ������ ����
        public GameObject interactionUI;//UI����
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
                interactionUI.SetActive(true); // UI ǥ��
                if (Input.GetKeyDown(KeyCode.F))
                {
                    nearestInteractable.Interact();
                }
            }
            else
            {
                interactionUI.SetActive(false); // UI ����
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
