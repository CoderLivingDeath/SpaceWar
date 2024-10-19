using Assets.Project.Scripts.Controllers.ShootController;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.Infrastructure.Spawner
{
    public class BulletSpawner
    {
        private DiContainer _container;

        public BulletSpawner(DiContainer container)
        {
            _container = container;
        }

        public GameObject Spawn(BulletShotConfig config, Vector3 position, Quaternion rotation)
        {
            GameObjectCreationParameters parameters = new GameObjectCreationParameters();
            parameters.Position = position;
            parameters.Rotation = rotation;

            var gameobjectBullet = _container.InstantiatePrefab(config.Prefab, parameters);

            gameobjectBullet.transform.localScale *= config.SizeScale;
            return gameobjectBullet;
        }
    }
}
