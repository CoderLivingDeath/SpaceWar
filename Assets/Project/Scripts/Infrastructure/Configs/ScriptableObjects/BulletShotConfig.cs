using UnityEngine;

namespace Assets.Project.Scripts.Controllers.ShootController
{
    [CreateAssetMenu(fileName = "BulletShotConfig", menuName = "Project/Weapon/BulletShotConfig", order = 1)]
    public class BulletShotConfig : ScriptableObject
    {
        public GameObject Prefab;
        public float BaseDamage;
        public float InitialSpeed;
    }
}