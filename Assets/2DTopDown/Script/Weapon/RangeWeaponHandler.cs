using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Topdown
{
    public class RangeWeaponHandler : WeaponHandler
    {

        [Header("Ranged Attack Data")]
        [SerializeField] private Transform projectileSpawnPosition;

        [SerializeField] private int bulletIndex;
        public int BulletIndex { get { return bulletIndex; } }

        [SerializeField] private float bulletSize = 1;
        public float BulletSize { get { return bulletSize; } }

        [SerializeField] private float duration;
        public float Duration { get { return duration; } }

        [SerializeField] private float spread;
        public float Spread { get { return spread; } }

        [SerializeField] private int numberofProjectilesPerShot;
        public int NumberofProjectilesPerShot { get { return numberofProjectilesPerShot; } }

        [SerializeField] private float multipleProjectilesAngel;
        public float MultipleProjectilesAngel { get { return multipleProjectilesAngel; } }

        [SerializeField] private Color projectileColor;
        public Color ProjectileColor { get { return projectileColor; } }

        private ProjectileManager projectileManager;
        protected override void Start()
        {
            base.Start();
            projectileManager =  ProjectileManager.Instance;
        }

        public override void Attack()
        {
            base.Attack();
            Debug.Log("RangeWeaponHandler Attack 메서드 호출됨");

            float projectilesAngleSpace = multipleProjectilesAngel;
            int numberOfProjectilesPerShot = numberofProjectilesPerShot;

            Debug.Log("numberOfProjectilesPerShot: " + numberOfProjectilesPerShot);

            float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * multipleProjectilesAngel;

            for (int i = 0; i < numberOfProjectilesPerShot; i++)
            {
                float angle = minAngle + projectilesAngleSpace * i;
                float randomSpread = Random.Range(-spread, spread);
                angle += randomSpread;
                Debug.Log("CreateProjectile 호출 전");
                CreateProjectile(Controller.LookDirection, angle);
            }
            Debug.Log("화살을 만들어라!");
        }

        private void CreateProjectile(Vector2 lookDirection, float angle)
        {
            Debug.Log("CreateProjectile 메서드 호출됨");
            Debug.Log("lookDirection: " + lookDirection);

            projectileManager.ShootBullet(
                this,
                projectileSpawnPosition.position,
                RotateVector2(lookDirection, angle));
            Debug.Log("화살 만드는중");
        }
        private static Vector2 RotateVector2(Vector2 v, float degree)
        {
            return Quaternion.Euler(0, 0, degree) * v;
        }
    }
}
