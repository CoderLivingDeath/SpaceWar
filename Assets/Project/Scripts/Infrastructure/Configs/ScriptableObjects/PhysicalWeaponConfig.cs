using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project.Scripts.Controllers.ShootController
{
    [CreateAssetMenu(fileName = "PhysicalWeaponConfig", menuName = "Project/Weapon/PhysicalWeaponConfig", order = 1)]
    public class PhysicalWeaponConfig : ScriptableObject
    {
        public BulletShotConfig[] RegistredBullet;
        public int MaxBulletsInMagazine;
    }
}