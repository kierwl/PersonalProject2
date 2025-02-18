using UnityEngine;
namespace Topdown
{
    public class EnemyController : BaseController
    {
        private EnemyManager enemyManager; // �� ������ ����
        private Transform target; // ���� ������ ���

        [SerializeField] private float followRange = 15f; // ���� ������ �����ϴ� �Ÿ�

        // �� �ʱ�ȭ �޼���
        public void Init(EnemyManager enemyManager, Transform target)
        {
            this.enemyManager = enemyManager;
            this.target = target;
        }

        // ������ �Ÿ� ��� �޼���
        protected float DistanceToTarget()
        {
            return Vector3.Distance(transform.position, target.position);
        }

        // ���� �ൿ�� ó���ϴ� �޼���
        protected override void HandleAction()
        {
            base.HandleAction();

            // ���� �ڵ鷯�� ����� ������ �̵��� ����
            if (weaponHandler == null || target == null)
            {
                if (!movementDirection.Equals(Vector2.zero)) movementDirection = Vector2.zero;
                return;
            }

            float distance = DistanceToTarget(); // ������ �Ÿ� ���
            Vector2 direction = DirectionToTarget(); // ��� ���� ���

            isAttacking = false;
            if (distance <= followRange) // ����� ���� ���� ���� �ִ��� Ȯ��
            {
                lookDirection = direction; // ���� �ü� ���� ����

                if (distance <= weaponHandler.AttackRange) // ����� ���� ���� ���� �ִ��� Ȯ��
                {
                    int layerMaskTarget = weaponHandler.target;
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, weaponHandler.AttackRange * 1.5f,
                        (1 << LayerMask.NameToLayer("Level")) | layerMaskTarget);

                    // ���� ������ ����� �ִ��� Ȯ��
                    if (hit.collider != null && layerMaskTarget == (layerMaskTarget | (1 << hit.collider.gameObject.layer)))
                    {
                        isAttacking = true;
                    }

                    movementDirection = Vector2.zero; // ���� �߿��� �̵����� ����
                    return;
                }

                movementDirection = direction; // ��� �������� �̵�
            }
        }

        // ��� ���� ��� �޼���
        protected Vector2 DirectionToTarget()
        {
            return (target.position - transform.position).normalized;
        }

        // ���� �׾��� �� ȣ��Ǵ� �޼���
        public override void Death()
        {
            base.Death();
            enemyManager.RemoveEnemyOnDeath(this); // �� �����ڿ��� �� ����
        }
    }

}

