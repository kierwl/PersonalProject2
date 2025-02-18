using UnityEngine;
namespace Topdown
{
    public class EnemyController : BaseController
    {
        private EnemyManager enemyManager; // 적 관리자 참조
        private Transform target; // 적이 추적할 대상

        [SerializeField] private float followRange = 15f; // 적이 추적을 시작하는 거리

        // 적 초기화 메서드
        public void Init(EnemyManager enemyManager, Transform target)
        {
            this.enemyManager = enemyManager;
            this.target = target;
        }

        // 대상과의 거리 계산 메서드
        protected float DistanceToTarget()
        {
            return Vector3.Distance(transform.position, target.position);
        }

        // 적의 행동을 처리하는 메서드
        protected override void HandleAction()
        {
            base.HandleAction();

            // 무기 핸들러나 대상이 없으면 이동을 멈춤
            if (weaponHandler == null || target == null)
            {
                if (!movementDirection.Equals(Vector2.zero)) movementDirection = Vector2.zero;
                return;
            }

            float distance = DistanceToTarget(); // 대상과의 거리 계산
            Vector2 direction = DirectionToTarget(); // 대상 방향 계산

            isAttacking = false;
            if (distance <= followRange) // 대상이 추적 범위 내에 있는지 확인
            {
                lookDirection = direction; // 적의 시선 방향 설정

                if (distance <= weaponHandler.AttackRange) // 대상이 공격 범위 내에 있는지 확인
                {
                    int layerMaskTarget = weaponHandler.target;
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, weaponHandler.AttackRange * 1.5f,
                        (1 << LayerMask.NameToLayer("Level")) | layerMaskTarget);

                    // 공격 가능한 대상이 있는지 확인
                    if (hit.collider != null && layerMaskTarget == (layerMaskTarget | (1 << hit.collider.gameObject.layer)))
                    {
                        isAttacking = true;
                    }

                    movementDirection = Vector2.zero; // 공격 중에는 이동하지 않음
                    return;
                }

                movementDirection = direction; // 대상 방향으로 이동
            }
        }

        // 대상 방향 계산 메서드
        protected Vector2 DirectionToTarget()
        {
            return (target.position - transform.position).normalized;
        }

        // 적이 죽었을 때 호출되는 메서드
        public override void Death()
        {
            base.Death();
            enemyManager.RemoveEnemyOnDeath(this); // 적 관리자에서 적 제거
        }
    }

}

