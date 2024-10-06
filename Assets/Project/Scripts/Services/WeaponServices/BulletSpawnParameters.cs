using Assets.Project.Scripts.Controllers.ShootController;
using UnityEngine;

namespace Assets.Project.Scripts.Services.WeaponServices
{
    public readonly struct BulletSpawnParameters
    {
        public readonly BulletShotConfig config;
        public readonly Vector3 position;
        public readonly Quaternion rotation;

        public BulletSpawnParameters(BulletShotConfig config, Vector3 position, Quaternion rotation)
        {
            this.config = config;
            this.position = position;
            this.rotation = rotation;
        }
    }
}