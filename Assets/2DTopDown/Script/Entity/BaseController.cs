using UnityEngine;
namespace Topdown
{
    public class BaseController : MonoBehaviour
    {
        protected Rigidbody2D _rigidbody; // Rigidbody2D 컴포넌트 참조

        [SerializeField] private SpriteRenderer characterRenderer; // 캐릭터의 SpriteRenderer 참조
        [SerializeField] private Transform weaponPivot; // 무기 피벗 위치 참조

        protected Vector2 movementDirection = Vector2.zero; // 이동 방향
        public Vector2 MovementDirection { get { return movementDirection; } }

        protected Vector2 lookDirection = Vector2.zero; // 시선 방향
        public Vector2 LookDirection { get { return lookDirection; } }

        private Vector2 knockback = Vector2.zero; // 넉백 벡터
        private float knockbackDuration = 0.0f; // 넉백 지속 시간

        protected AnimationHandler animationHandler; // 애니메이션 핸들러 참조

        protected StatHandler statHandler; // 스탯 핸들러 참조

        [SerializeField] public WeaponHandler WeaponPrefab; // 무기 프리팹 참조
        protected WeaponHandler weaponHandler; // 무기 핸들러 참조

        protected bool isAttacking; // 공격 중인지 여부
        private float timeSinceLastAttack = float.MaxValue; // 마지막 공격 이후 경과 시간

        // 초기화 메서드
        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            animationHandler = GetComponent<AnimationHandler>();
            statHandler = GetComponent<StatHandler>();

            if (WeaponPrefab != null)
                weaponHandler = Instantiate(WeaponPrefab, weaponPivot);
            else
                weaponHandler = GetComponentInChildren<WeaponHandler>();
        }

        // 시작 시 호출되는 메서드
        protected virtual void Start()
        {

        }

        // 매 프레임마다 호출되는 메서드
        protected virtual void Update()
        {
            HandleAction();
            Rotate(lookDirection);
            HandleAttackDelay();
        }

        // 물리 업데이트마다 호출되는 메서드
        protected virtual void FixedUpdate()
        {
            Movment(movementDirection);
            if (knockbackDuration > 0.0f)
            {
                knockbackDuration -= Time.fixedDeltaTime;
            }
        }

        // 행동을 처리하는 메서드 (상속받은 클래스에서 구현)
        protected virtual void HandleAction()
        {

        }

        // 이동을 처리하는 메서드
        private void Movment(Vector2 direction)
        {
            direction = direction * statHandler.Speed;
            if (knockbackDuration > 0.0f)
            {
                direction *= 0.2f;
                direction += knockback;
            }

            _rigidbody.velocity = direction;
            animationHandler.Move(direction);
        }

        // 회전을 처리하는 메서드
        private void Rotate(Vector2 direction)
        {
            float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bool isLeft = Mathf.Abs(rotZ) > 90f;

            characterRenderer.flipX = isLeft;

            if (weaponPivot != null)
            {
                weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ);
            }

            weaponHandler?.Rotate(isLeft);
        }

        // 넉백을 적용하는 메서드
        public void ApplyKnockback(Transform other, float power, float duration)
        {
            knockbackDuration = duration;
            knockback = -(other.position - transform.position).normalized * power;
        }

        // 공격 지연을 처리하는 메서드
        private void HandleAttackDelay()
        {
            if (weaponHandler == null)
                return;

            if (timeSinceLastAttack <= weaponHandler.Delay)
            {
                timeSinceLastAttack += Time.deltaTime;
            }

            if (isAttacking && timeSinceLastAttack > weaponHandler.Delay)
            {
                timeSinceLastAttack = 0;
                Attack();
            }
        }

        // 공격을 처리하는 메서드 (상속받은 클래스에서 구현)
        protected virtual void Attack()
        {
            if (lookDirection != Vector2.zero)
                weaponHandler?.Attack();
        }

        // 캐릭터가 죽었을 때 호출되는 메서드
        public virtual void Death()
        {
            _rigidbody.velocity = Vector3.zero;

            foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
            {
                Color color = renderer.color;
                color.a = 0.3f;
                renderer.color = color;
            }

            foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
            {
                component.enabled = false;
            }

            Destroy(gameObject, 2f);
        }
    }


}
