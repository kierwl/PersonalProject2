using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Topdown
{
    public class ProjectileManager : MonoBehaviour
    {
        private static ProjectileManager instance;
        public static ProjectileManager Instance { get { return instance; } }

        [SerializeField] private GameObject[] projectilePrefabs;

        private void Awake()
        {
            instance = this;
        }

        public void ShootBullet(RangeWeaponHandler rangeWeaponHandler, Vector2 startPostiion, Vector2 direction)
        {
            Debug.Log("ShootBullet 메서드 호출됨");

            GameObject origin = projectilePrefabs[rangeWeaponHandler.BulletIndex];
            GameObject obj = Instantiate(origin, startPostiion, Quaternion.identity);

            ProjectileController projectileController = obj.GetComponent<ProjectileController>();
            projectileController.Init(direction, rangeWeaponHandler);
        }

    }
}

